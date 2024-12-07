using Microsoft.EntityFrameworkCore;
using WildlifePoaching.API.Data.Repositories.Interfaces;
using WildlifePoaching.API.Models.Domain;

namespace WildlifePoaching.API.Data.Repositories.Implementations
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext context, ILogger<Repository<Role>> logger)
        : base(context, logger)
        {
        }

        public async Task<Role> GetByNameAsync(string name)
        {
            return await _context.Roles
                .Include(r => r.Permissions)
                .FirstOrDefaultAsync(r => r.Name == name && !r.IsDeleted);
        }
    }
}
