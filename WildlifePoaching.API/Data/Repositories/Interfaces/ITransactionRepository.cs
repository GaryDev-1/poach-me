using WildlifePoaching.API.Models.Domain;

namespace WildlifePoaching.API.Data.Repositories.Interfaces
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        Task<IEnumerable<Transaction>> GetByUserIdAsync(int userId);
        Task<IEnumerable<Transaction>> GetByAnimalIdAsync(int animalId);
    }
}
