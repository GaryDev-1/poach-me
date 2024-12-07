using WildlifePoaching.API.Models.Domain;

namespace WildlifePoaching.API.Data.Repositories.Interfaces
{
    public interface IAnimalRepository : IRepository<Animal>
    {
        Task<IEnumerable<Animal>> GetByTypeAsync(int typeId);
        Task<IEnumerable<Animal>> GetByLocationAsync(int locationId);
        Task<Animal> GetWithImagesAsync(int id);
    }
}
