namespace BankAccount.Core.Model
{
    public class Account
    {
        public int Id { get; internal set; }
        public string? AccountNumber { get; internal set; }
        public decimal Balance { get; internal set; }

    }
}
