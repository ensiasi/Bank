using BankAccount.Core.Ports.Driven;

namespace BankAccount.Core.UseCase
{
    public class SavingTransactionService : ITransactionService<SavingsAccount>
    {
        private readonly ITransactionRepository<SavingsAccount> _accountRepository;
        public SavingTransactionService(ITransactionRepository<SavingsAccount> accountRepository)
        {
                _accountRepository = accountRepository;
        }
        public async Task<SavingsAccount> Deposit(SavingsAccount account, decimal amount)
        {
            if(account.Balance + amount > account.depositceiling)
            {
                throw new Exception("Deposit amount exceeds the limit.");
            }
            account.Balance += amount;
            await _accountRepository.Save(account);
            return account;
        }

        public async Task<SavingsAccount> Withdraw(SavingsAccount account, decimal amount)
        {
            if (amount > account.Balance)
            {
                throw new Exception("Withdrawal amount exceeds the balance.");
            }
            account.Balance -= amount;
            await _accountRepository.Save(account);
            return account;
        }
    }

}
