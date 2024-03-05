using BankAccount.Core.Model;
using BankAccount.Core.Ports.Driven;
using BankAccount.Core.Ports.Driving;

namespace BankAccount.Core.UseCase
{
    public class TransactionHistoryService : ITransactionHistoryService
    {
        private readonly ITransactionHistoryRepository _transactionHistoryRepository;
        public TransactionHistoryService(ITransactionHistoryRepository transactionHistoryRepository)
        {
            _transactionHistoryRepository = transactionHistoryRepository;
        }
        public async Task AddTransaction(int accountId, decimal amount, TransactionType type)
        {
            var transaction = new TransactionInfo
            {
                AccountId = accountId,
                Amount = amount,
                Type = type
            };
            // Save transaction to database
            await _transactionHistoryRepository.AddTransaction(transaction);

        }

        public Task<IEnumerable<TransactionInfo>> GetTransactionHistory(int accountId, DateTime startDate, DateTime endDate)
        {
            return _transactionHistoryRepository.GetTransactionHistory(accountId,startDate,endDate);
        }
    }
}
