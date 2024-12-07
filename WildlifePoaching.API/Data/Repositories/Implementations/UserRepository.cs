using Microsoft.EntityFrameworkCore;
using WildlifePoaching.API.Data.Repositories.Interfaces;
using WildlifePoaching.API.Models.Domain;

namespace WildlifePoaching.API.Data.Repositories.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context, ILogger<Repository<User>> logger) : base(context, logger)
        {
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == email && !u.IsDeleted);
        }

        public async Task<User> GetByRefreshTokenAsync(string refreshToken)
        {
            return await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.RefreshToken == refreshToken && !u.IsDeleted);
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email && !u.IsDeleted);
        }

        public async Task<Role> GetDefaultRoleAsync()
        {
            return await _context.Roles
                .FirstOrDefaultAsync(r => r.Name == "User")
                ?? throw new InvalidOperationException("Default role not found");
        }
    }
}
