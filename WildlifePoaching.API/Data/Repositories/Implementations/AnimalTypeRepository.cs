using Microsoft.EntityFrameworkCore;
using WildlifePoaching.API.Data.Repositories.Interfaces;
using WildlifePoaching.API.Models.Domain;

namespace WildlifePoaching.API.Data.Repositories.Implementations
{
    public class AnimalTypeRepository : Repository<AnimalType>, IAnimalTypeRepository
    {
        public AnimalTypeRepository(ApplicationDbContext context, ILogger<Repository<AnimalType>> logger)
        : base(context, logger)
        {
        }

        public async Task<IEnumerable<AnimalType>> GetByCategoryAsync(string category)
        {
            return await _context.AnimalTypes
                .Where(at => at.Category == category && !at.IsDeleted)
                .ToListAsync();
        }
    }
}
