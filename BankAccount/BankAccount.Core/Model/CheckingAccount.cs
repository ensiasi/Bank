using BankAccount.Core.Model;

namespace BankAccount.Core
{
    public class CheckingAccount : Account
    {
        public bool IsOverDraftEnabled { get; set; }
        public decimal OverDraftLimit { get; set; }
    }
}