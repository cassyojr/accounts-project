using Domain.Dto;
using Domain.Entity;
using Domain.Repository;
using Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Account> GetByIdAsync(int accountId)
        {
            if (accountId == 0) return null;
            return await _accountRepository.GetByIdAsync(accountId);
        }

        public async Task ResetRecordsAsync()
        {
            await _accountRepository.DeleteAllAsync();
        }

        public async Task<Account> DepositAsync(int destinationAccountId, decimal amount)
        {
            var accountExists = await _accountRepository.IsExistent(destinationAccountId);

            if (accountExists)
                return await _accountRepository.DepositAsync(destinationAccountId, amount);
            else
            {
                var account = new Account { AccountId = destinationAccountId, Balance = amount };

                return await _accountRepository.AddAsync(account);
            }
        }

        public async Task<Account> WithdrawAsync(int originAccountId, decimal amount)
        {
            var accountExists = await _accountRepository.IsExistent(originAccountId);

            if (!accountExists) return null;

            return await _accountRepository.WithdrawAsync(originAccountId, amount);
        }

        public async Task<AccountTransferDto> TransferAsync(int originAccountId, int destinationAccountId, decimal amount)
        {
            var originAccountExists = await _accountRepository.IsExistent(originAccountId);

            if (!originAccountExists) return null;

            var originAccount = await WithdrawAsync(originAccountId, amount);
            var destinationAccount = await DepositAsync(destinationAccountId, amount);

            return new AccountTransferDto
            {
                Origin = originAccount,
                Destination = destinationAccount
            };
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            return await _accountRepository.GetAll();
        }
    }
}
