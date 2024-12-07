using WildlifePoaching.API.Data.Repositories.Interfaces;
using WildlifePoaching.API.Models.Domain;
using WildlifePoaching.API.Models.DTOs.Auth;
using WildlifePoaching.API.Models.Enums;
using WildlifePoaching.API.Models.Exceptions;
using WildlifePoaching.API.Services.Interfaces;

namespace WildlifePoaching.API.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IPasswordService _passwordService;
        private readonly ILogger<AuthService> _logger;

        public AuthService(
            IUserRepository userRepository,
            ITokenService tokenService,
            IPasswordService passwordService,
            ILogger<AuthService> logger)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _passwordService = passwordService;
            _logger = logger;
        }

        public async Task<AuthResponse> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null || !_passwordService.VerifyPassword(password, user.PasswordHash))
            {
                _logger.LogWarning("Failed login attempt for email: {Email}", email);
                throw new UnauthorizedAccessException("Invalid credentials");
            }

            if (user.Status != UserStatus.Active)
            {
                _logger.LogWarning("Login attempt for inactive account: {Email}", email);
                throw new UnauthorizedAccessException("Account is not active");
            }

            var token = _tokenService.GenerateJwtToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryDate = DateTime.UtcNow.AddDays(7);
            user.LastLoginDate = DateTime.UtcNow;
            user.LoginAttempts = 0;

            await _userRepository.UpdateAsync(user);

            _logger.LogInformation("Successful login for user: {Email}", email);

            return new AuthResponse
            {
                Token = token,
                RefreshToken = refreshToken,
                UserId = user.Id,
                Email = user.Email,
                Username = user.Username,
                Role = user.Role.Name
            };
        }

        public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
        {
            if (await _userRepository.EmailExistsAsync(request.Email))
            {
                _logger.LogWarning("Registration attempt with existing email: {Email}", request.Email);
                throw new ValidationException("Email already exists");
            }

            var hashedPassword = _passwordService.HashPassword(request.Password);
            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                PasswordHash = hashedPassword,
                Role = await _userRepository.GetDefaultRoleAsync(),
                Status = UserStatus.Active,
                CreatedAt = DateTime.UtcNow
            };

            await _userRepository.AddAsync(user);

            var token = _tokenService.GenerateJwtToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryDate = DateTime.UtcNow.AddDays(7);
            await _userRepository.UpdateAsync(user);

            _logger.LogInformation("New user registered: {Email}", request.Email);

            return new AuthResponse
            {
                Token = token,
                RefreshToken = refreshToken,
                UserId = user.Id,
                Email = user.Email,
                Username = user.Username,
                Role = user.Role.Name
            };
        }

        public async Task<AuthResponse> RefreshTokenAsync(string refreshToken)
        {
            var user = await _userRepository.GetByRefreshTokenAsync(refreshToken);
            if (user == null ||
                user.RefreshToken != refreshToken ||
                user.RefreshTokenExpiryDate <= DateTime.UtcNow)
            {
                _logger.LogWarning("Invalid refresh token attempt");
                throw new UnauthorizedAccessException("Invalid refresh token");
            }

            var newToken = _tokenService.GenerateJwtToken(user);
            var newRefreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryDate = DateTime.UtcNow.AddDays(7);
            await _userRepository.UpdateAsync(user);

            _logger.LogInformation("Token refreshed for user: {Email}", user.Email);

            return new AuthResponse
            {
                Token = newToken,
                RefreshToken = newRefreshToken,
                UserId = user.Id,
                Email = user.Email,
                Username = user.Username,
                Role = user.Role.Name
            };
        }

        public async Task LogoutAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                _logger.LogWarning("Logout attempt for non-existent user ID: {UserId}", userId);
                throw new NotFoundException("User not found");
            }

            user.RefreshToken = null;
            user.RefreshTokenExpiryDate = null;
            await _userRepository.UpdateAsync(user);

            _logger.LogInformation("User logged out: {Email}", user.Email);
        }
    }
}
