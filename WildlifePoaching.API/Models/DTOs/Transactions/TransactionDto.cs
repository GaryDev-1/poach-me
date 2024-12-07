using WildlifePoaching.API.Models.Enums;

namespace WildlifePoaching.API.Models.DTOs.Transactions
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public string AnimalName { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public TransactionType TransactionType { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
