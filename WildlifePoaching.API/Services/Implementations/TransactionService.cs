using AutoMapper;
using WildlifePoaching.API.Data.Repositories.Interfaces;
using WildlifePoaching.API.Models.Domain;
using WildlifePoaching.API.Models.DTOs.Transactions;
using WildlifePoaching.API.Services.Interfaces;

namespace WildlifePoaching.API.Services.Implementations
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<TransactionService> _logger;

        public TransactionService(
            ITransactionRepository transactionRepository,
            IMapper mapper,
            ILogger<TransactionService> logger)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<TransactionDto> CreateTransactionAsync(CreateTransactionDto dto)
        {
            var transaction = _mapper.Map<Transaction>(dto);
            await _transactionRepository.AddAsync(transaction);
            return _mapper.Map<TransactionDto>(transaction);
        }

        public async Task<IEnumerable<TransactionDto>> GetUserTransactionsAsync(int userId)
        {
            var transactions = await _transactionRepository.GetByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<TransactionDto>>(transactions);
        }

        public async Task<TransactionDto> GetTransactionByIdAsync(int id)
        {
            var transaction = await _transactionRepository.GetByIdAsync(id);
            return _mapper.Map<TransactionDto>(transaction);
        }
    }
}
