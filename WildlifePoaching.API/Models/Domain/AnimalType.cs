using WildlifePoaching.API.Models.Domain.Common;

namespace WildlifePoaching.API.Models.Domain
{
    public class AnimalType : BaseEntity
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string SpecialRequirements { get; set; }
        public ICollection<Animal> Animals { get; set; }
    }
}
