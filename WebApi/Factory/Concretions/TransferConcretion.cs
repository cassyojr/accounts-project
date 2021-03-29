using Domain.Services;
using Accounts.Project.ViewModel;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Accounts.Project.Factory.Concretions
{
    public class TransferConcretion : EventConcretion
    {
        private readonly IAccountService _accountService;

        public TransferConcretion(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public override async Task<string> ExecuteEvent(Event eventModel)
        {
            var origin = Convert.ToInt32(eventModel.Origin);
            var destination = Convert.ToInt32(eventModel.Destination);

            var result = await _accountService.TransferAsync(origin, destination, eventModel.Amount);

            return result is null ? null : JsonSerializer.Serialize(new
            {
                origin = new
                {
                    id = $"{result.Origin.AccountId}",
                    balance = result.Origin.Balance
                },
                destination = new
                {
                    id = $"{result.Destination.AccountId}",
                    balance = result.Destination.Balance
                }
            });
        }
    }
}
