using BankAccount.Core.Model;

namespace BankAccount.Core.Ports.Driving
{
    public interface ITransactionHistoryService
    {
        Task AddTransaction(int accountId, decimal amount, TransactionType type);
        Task<IEnumerable<TransactionInfo>> GetTransactionHistory(int accountId, DateTime startDate, DateTime endDate);
    }
}
