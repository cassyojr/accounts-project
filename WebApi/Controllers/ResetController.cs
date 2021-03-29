using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;

namespace Accounts.Project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ResetController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public ResetController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> PostResetState()
        {
            await _accountService.ResetRecordsAsync();
            return Ok("OK");
        }
    }
}
