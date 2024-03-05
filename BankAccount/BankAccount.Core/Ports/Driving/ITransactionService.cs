using BankAccount.Core.Model;

namespace BankAccount.Core
{
    public interface ITransactionService<T> where T : Account
    {
        Task<T> Deposit(T account, decimal amount);
        Task<T> Withdraw(T account, decimal amount);
    }
}