using WildlifePoaching.API.Models.DTOs.Transactions;

namespace WildlifePoaching.API.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<TransactionDto> CreateTransactionAsync(CreateTransactionDto dto);
        Task<IEnumerable<TransactionDto>> GetUserTransactionsAsync(int userId);
        Task<TransactionDto> GetTransactionByIdAsync(int id);
    }
}
