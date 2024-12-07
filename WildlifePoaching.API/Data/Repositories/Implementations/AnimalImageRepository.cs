using Microsoft.EntityFrameworkCore;
using WildlifePoaching.API.Data.Repositories.Interfaces;
using WildlifePoaching.API.Models.Domain;

namespace WildlifePoaching.API.Data.Repositories.Implementations
{
    public class AnimalImageRepository : Repository<AnimalImage>, IAnimalImageRepository
    {
        public AnimalImageRepository(ApplicationDbContext context, ILogger<Repository<AnimalImage>> logger)
        : base(context, logger)
        {
        }

        public async Task<IEnumerable<AnimalImage>> GetByAnimalIdAsync(int animalId)
        {
            return await _context.AnimalImages
                .Where(ai => ai.AnimalId == animalId && !ai.IsDeleted)
                .ToListAsync();
        }

        public async Task<AnimalImage> GetPrimaryImageAsync(int animalId)
        {
            return await _context.AnimalImages
                .FirstOrDefaultAsync(ai => ai.AnimalId == animalId && ai.IsPrimary && !ai.IsDeleted);
        }
    }
}
