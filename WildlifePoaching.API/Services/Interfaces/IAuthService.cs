using WildlifePoaching.API.Models.DTOs.Auth;

namespace WildlifePoaching.API.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> LoginAsync(string email, string password);
        Task<AuthResponse> RegisterAsync(RegisterRequest request);
        Task<AuthResponse> RefreshTokenAsync(string refreshToken);
        Task LogoutAsync(int userId);
    }
}
