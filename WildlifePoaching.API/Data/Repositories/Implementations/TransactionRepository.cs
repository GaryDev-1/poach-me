using Microsoft.EntityFrameworkCore;
using WildlifePoaching.API.Data.Repositories.Interfaces;
using WildlifePoaching.API.Models.Domain;

namespace WildlifePoaching.API.Data.Repositories.Implementations
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(ApplicationDbContext context, ILogger<Repository<Transaction>> logger)
        : base(context, logger)
        {
        }

        public async Task<IEnumerable<Transaction>> GetByUserIdAsync(int userId)
        {
            return await _context.Transactions
                .Include(t => t.Animal)
                .Include(t => t.User)
                .Where(t => t.UserId == userId && !t.IsDeleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<Transaction>> GetByAnimalIdAsync(int animalId)
        {
            return await _context.Transactions
                .Include(t => t.Animal)
                .Include(t => t.User)
                .Where(t => t.AnimalId == animalId && !t.IsDeleted)
                .ToListAsync();
        }
    }
}
