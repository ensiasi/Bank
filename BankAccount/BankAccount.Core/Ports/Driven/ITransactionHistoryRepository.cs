using BankAccount.Core.Model;
namespace BankAccount.Core.Ports.Driven
{
    public interface ITransactionHistoryRepository
    {
        Task AddTransaction(TransactionInfo transaction);
        Task<IEnumerable<TransactionInfo>> GetTransactionHistory(int accountId, DateTime startDate, DateTime endDate);
    }
}
