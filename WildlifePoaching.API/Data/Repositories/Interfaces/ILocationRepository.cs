using WildlifePoaching.API.Models.Domain;

namespace WildlifePoaching.API.Data.Repositories.Interfaces
{
    public interface ILocationRepository : IRepository<Location>
    {
        Task<IEnumerable<Location>> GetByCountryAsync(string country);
    }
}
