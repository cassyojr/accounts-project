using Domain.Dto;
using Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IAccountService
    {
        /// <summary>
        /// Asynchronously get the account entity by id.
        /// </summary>
        /// <param name="accountId">Account id to be returned</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// Task result containing an Account instance or null if not found.
        /// </returns>
        Task<Account> GetByIdAsync(int accountId);

        /// <summary>
        /// Asynchronously remove all in memory database data.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task ResetRecordsAsync();

        /// <summary>
        /// Asynchronously deposit an amount to an existing account or create an unexisting account with the informed amount.
        /// </summary>
        /// <param name="destinationAccountId">Account id to deposit</param>
        /// <param name="amount">Amount to be deposited</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The result containing the deposited Account, or null if the account was not found.
        /// </returns>
        Task<Account> DepositAsync(int destinationAccountId, decimal amount);

        /// <summary>
        /// Asynchronously withdraw an amount from one account.
        /// </summary>
        /// <param name="originAccountId">Account id to withdrawn</param>
        /// <param name="amount">Amount to withdrawn</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The result containing the deposited Account, or null if the account was not found.
        /// </returns>
        Task<Account> WithdrawAsync(int originAccountId, decimal amount);

        /// <summary>
        /// Asynchronously withdraw an amount from one account.
        /// </summary>
        /// <param name="originAccountId">Account id to withdrawn</param>
        ///  <param name="destinationAccountId">Account id to deposit</param>
        /// <param name="amount">Amount to transfer</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The result containing the origin Account, the destination Account, or null if any of the accounts was not found.
        /// </returns>
        Task<AccountTransferDto> TransferAsync(int originAccountId, int destinationAccountId, decimal amount);

        Task<IEnumerable<Account>> GetAll();
    }
}
