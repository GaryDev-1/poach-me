using WildlifePoaching.API.Models.Enums;

namespace WildlifePoaching.API.Models.DTOs.Transactions
{
    public class CreateTransactionDto
    {
        public int AnimalId { get; set; }
        public int UserId { get; set; }
        public TransactionType TransactionType { get; set; }
        public decimal Amount { get; set; }
    }
}
