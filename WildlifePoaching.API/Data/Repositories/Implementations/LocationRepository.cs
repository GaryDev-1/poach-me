using Microsoft.EntityFrameworkCore;
using WildlifePoaching.API.Data.Repositories.Interfaces;
using WildlifePoaching.API.Models.Domain;

namespace WildlifePoaching.API.Data.Repositories.Implementations
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(ApplicationDbContext context, ILogger<Repository<Location>> logger)
        : base(context, logger)
        {
        }

        public async Task<IEnumerable<Location>> GetByCountryAsync(string country)
        {
            return await _context.Locations
                .Where(l => l.Country == country && !l.IsDeleted)
                .ToListAsync();
        }
    }
}
