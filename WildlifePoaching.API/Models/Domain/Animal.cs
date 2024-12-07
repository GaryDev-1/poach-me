using WildlifePoaching.API.Models.Domain.Common;

namespace WildlifePoaching.API.Models.Domain
{
    public class Animal : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime AcquisitionDate { get; set; }
        public int LocationId { get; set; }
        public int AnimalTypeId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        // Navigation properties
        public Location StolenFrom { get; set; }
        public AnimalType Type { get; set; }
        public ICollection<AnimalImage> Images { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
