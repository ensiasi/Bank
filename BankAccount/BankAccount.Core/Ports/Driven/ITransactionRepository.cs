using BankAccount.Core.Model;
namespace BankAccount.Core.Ports.Driven
{
    public interface ITransactionRepository<T> where T : Account
    {
        Task Save(T account);
        Task<T> GetById(int id);
    }
}
