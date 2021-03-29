using Domain.Services;
using Accounts.Project.ViewModel;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Accounts.Project.Factory.Concretions
{
    public class WithdrawConcretion : EventConcretion
    {
        private readonly IAccountService _accountService;

        public WithdrawConcretion(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public override async Task<string> ExecuteEvent(Event eventModel)
        {
            var origin = Convert.ToInt32(eventModel.Origin);

            var result = await _accountService.WithdrawAsync(origin, eventModel.Amount);

            return result is null ? null : JsonSerializer.Serialize(new
            {
                origin = new
                {
                    id = $"{result.AccountId}",
                    balance = result.Balance
                }
            });
        }
    }
}
