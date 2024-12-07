using WildlifePoaching.API.Models.Domain;

namespace WildlifePoaching.API.Data.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByRefreshTokenAsync(string refreshToken);
        Task<bool> EmailExistsAsync(string email);
        Task<Role> GetDefaultRoleAsync();
    }
}
