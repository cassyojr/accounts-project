using Domain.Entity;
using Domain.Repository;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

namespace Infrastructure.Repository
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task DeleteAllAsync()
        {
            var records = await _context.Account.ToListAsync();

            _context.Account.RemoveRange(records);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsExistent(int accountId)
        {
            return await _context.Account.AnyAsync(x => x.AccountId == accountId);
        }

        public async Task<Account> DepositAsync(int destinationAccountId, decimal amount)
        {
            var account = await GetByIdAsync(destinationAccountId);

            if (account is null) throw new NullReferenceException("Account cannot be null");

            account.Balance += amount;

            _context.Account.Update(account);

            await _context.SaveChangesAsync();

            return account;
        }

        public async Task<Account> WithdrawAsync(int originAccountId, decimal amount)
        {
            var account = await GetByIdAsync(originAccountId);

            if (account is null) throw new NullReferenceException("Account cannot be null");

            account.Balance -= amount;

            _context.Account.Update(account);

            await _context.SaveChangesAsync();

            return account;
        }
    }
}
