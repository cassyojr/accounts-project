using Domain.Entity;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        /// <summary>
        /// Asynchronously deletes all database records.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task DeleteAllAsync();

        /// <summary>
        /// Asynchronously checks if the account exists.
        /// </summary>
        /// <param name="accountId">Account id to verify</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// Task result containing true if account exists and false if it does not exists.
        /// </returns>
        Task<bool> IsExistent(int accountId);

        /// <summary>
        /// Asynchronously deposit an amount to an existing account.
        /// </summary>
        /// <param name="destinationAccountId">Account id to deposit</param>
        /// <param name="amount">Amount to be deposited</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The resust containing the deposited account.
        /// Throw a NullReferenceException if the account does not exists.
        /// </returns>
        Task<Account> DepositAsync(int destinationAccountId, decimal amount);

        /// <summary>
        /// Asynchronously withdrawn an amount from an existing account.
        /// </summary>
        /// <param name="originAccountId">Account id ot withdrawn</param>
        /// <param name="amount">Amount to be withdrawned</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The resust containing the account withdrawned.
        /// Throw a NullReferenceException if the account does not exists.
        /// </returns>
        Task<Account> WithdrawAsync(int originAccountId, decimal amount);
    }
}
