using WildlifePoaching.API.Models.Domain;

namespace WildlifePoaching.API.Data.Repositories.Interfaces
{
    public interface IAnimalTypeRepository : IRepository<AnimalType>
    {
        Task<IEnumerable<AnimalType>> GetByCategoryAsync(string category);
    }
}
