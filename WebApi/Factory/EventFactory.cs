using Domain.Services;
using Accounts.Project.Factory.Concretions;
using System;

namespace Accounts.Project.Factory
{
    public class EventFactory : IEventFactory
    {
        private readonly IAccountService _accountService;

        public EventFactory(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public EventConcretion Create(string eventType)
        {
            switch (eventType)
            {
                case "deposit":
                    return new DepositConcretion(_accountService);
                case "withdraw":
                    return new WithdrawConcretion(_accountService);
                case "transfer":
                    return new TransferConcretion(_accountService);
                default:
                    throw new Exception("Invalid event process to execute.");
            }
        }
    }
}
