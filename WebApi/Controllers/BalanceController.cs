using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Accounts.Project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BalanceController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public BalanceController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBalance([FromQuery(Name = "account_id")] int accountId)
        {
            var account = await _accountService.GetByIdAsync(accountId);

            if (account is null) return NotFound(0);

            return Ok(account.Balance);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetBalances()
        {
            var accounts = await _accountService.GetAll();

            return Ok(accounts);
        }
    }
}
