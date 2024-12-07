using Microsoft.EntityFrameworkCore;
using WildlifePoaching.API.Data.Repositories.Interfaces;
using WildlifePoaching.API.Models.Domain;

namespace WildlifePoaching.API.Data.Repositories.Implementations
{
    public class AnimalRepository : Repository<Animal>, IAnimalRepository
    {
        public AnimalRepository(ApplicationDbContext context, ILogger<Repository<Animal>> logger) : base(context, logger)
        {
        }

        public async Task<IEnumerable<Animal>> GetByTypeAsync(int typeId)
        {
            return await _context.Animals
                .Include(a => a.Type)
                .Include(a => a.StolenFrom)
                .Where(a => a.AnimalTypeId == typeId && !a.IsDeleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<Animal>> GetByLocationAsync(int locationId)
        {
            return await _context.Animals
                .Include(a => a.Type)
                .Include(a => a.StolenFrom)
                .Where(a => a.LocationId == locationId && !a.IsDeleted)
                .ToListAsync();
        }

        public async Task<Animal> GetWithImagesAsync(int id)
        {
            return await _context.Animals
                .Include(a => a.Type)
                .Include(a => a.StolenFrom)
                .Include(a => a.Images)
                .FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
        }
    }
}
