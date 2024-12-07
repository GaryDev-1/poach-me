using WildlifePoaching.API.Models.Domain;

namespace WildlifePoaching.API.Data.Repositories.Interfaces
{
    public interface IAnimalImageRepository : IRepository<AnimalImage>
    {
        Task<IEnumerable<AnimalImage>> GetByAnimalIdAsync(int animalId);
        Task<AnimalImage> GetPrimaryImageAsync(int animalId);
    }
}
