using BankAccount.Core.Model;
using BankAccount.Core.Ports.Driven;
using BankAccount.Core.Ports.Driving;

namespace BankAccount.Core.UseCase
{
    public class CheckingTransactionService : ITransactionService<CheckingAccount>
    {
        private readonly ITransactionRepository<CheckingAccount> _accountRepository;
        private readonly ITransactionHistoryRepository _transactionHistoryRepository;
        private readonly IOverDraftService _overDraftService;
        public CheckingTransactionService(ITransactionRepository<CheckingAccount> accountRepository,
                                          ITransactionHistoryRepository transactionHistoryRepository,
                                          IOverDraftService overDraftService)
        {
            _accountRepository = accountRepository;
            _transactionHistoryRepository = transactionHistoryRepository;
            _overDraftService = overDraftService;
        }

        public  async Task<CheckingAccount> Deposit(CheckingAccount account, decimal amount)
        {
            account.Balance += amount;
            await _accountRepository.Save(account);
            //record transaction
            await _transactionHistoryRepository.AddTransaction(new TransactionInfo
            {
                AccountId = account.Id,
                Amount = amount,
                Date = DateTime.Now,
                Type = TransactionType.Deposit
            });
            return account;
        }
        public async Task<CheckingAccount> Withdraw(CheckingAccount account, decimal amount)
        {
            _overDraftService.CheckOverDraft(account, amount);
            account.Balance -= amount;
            await _accountRepository.Save(account);
            await _transactionHistoryRepository.AddTransaction(new TransactionInfo
            {
                AccountId = account.Id,
                Amount = - amount,
                Date = DateTime.Now,
                Type = TransactionType.Withdraw
            });
            return account;
        }
    }

}
