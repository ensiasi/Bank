using BankAccount.Core.Model;

namespace BankAccount.Core.Ports.Driving
{
    public interface IOverDraftService
    {
        void CheckOverDraft(CheckingAccount account, decimal amount);
    }
}
