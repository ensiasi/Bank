using BankAccount.Core.Model;
using BankAccount.Core.Ports.Driving;

namespace BankAccount.Core.UseCase
{
    public class OverDraftService : IOverDraftService
    {
        public void CheckOverDraft(CheckingAccount account, decimal amount)
        {
            var newBalance = account.Balance - amount;
            if (newBalance < 0)
            {
                if ((!account.IsOverDraftEnabled))
                {
                    throw new Exception("Insufficient funds");
                }
                else if (Math.Abs(newBalance) > account.OverDraftLimit)
                {
                    throw new Exception("Overdraft limit exceeded");
                }
            }
        }
    }
}
