using BankAccount.Core.Model;

namespace BankAccount.Core
{
    public class SavingsAccount : Account
    {
        public decimal depositceiling { get; set; }
    }
}