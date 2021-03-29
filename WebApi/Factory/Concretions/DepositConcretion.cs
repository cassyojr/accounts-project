using Domain.Services;
using Accounts.Project.ViewModel;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Accounts.Project.Factory.Concretions
{
    public class DepositConcretion : EventConcretion
    {
        private readonly IAccountService _accountService;

        public DepositConcretion(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public override async Task<string> ExecuteEvent(Event eventModel)
        {
            var destination = Convert.ToInt32(eventModel.Destination);
            var result = await _accountService.DepositAsync(destination, eventModel.Amount);

            return result is null ? null : JsonSerializer.Serialize(new
            {
                destination = new
                {
                    id = $"{result.AccountId}",
                    balance = result.Balance
                }
            });
        }
    }
}
