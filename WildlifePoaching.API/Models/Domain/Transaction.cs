using WildlifePoaching.API.Models.Domain.Common;
using WildlifePoaching.API.Models.Enums;

namespace WildlifePoaching.API.Models.Domain
{
    public class Transaction : BaseEntity
    {
        public int AnimalId { get; set; }
        public int UserId { get; set; }
        public TransactionType TransactionType { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public DateTime TransactionDate { get; set; }

        // Navigation properties
        public Animal Animal { get; set; }
        public User User { get; set; }
    }
}
