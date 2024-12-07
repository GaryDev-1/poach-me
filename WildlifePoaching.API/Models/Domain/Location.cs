using WildlifePoaching.API.Models.Domain.Common;

namespace WildlifePoaching.API.Models.Domain
{
    public class Location : BaseEntity
    {
        public string Name { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int SecurityLevel { get; set; }
        public ICollection<Animal> Animals { get; set; }
    }
}
