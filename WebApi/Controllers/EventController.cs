using Domain.Services;
using Accounts.Project.Factory;
using Accounts.Project.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;

namespace Accounts.Project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventFactory _eventFactory;

        public EventController(IEventFactory eventFactory)
        {
            _eventFactory = eventFactory;
        }

        [HttpPost]
        public async Task<IActionResult> PostEvent([FromBody] Event eventModel)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid informations");
            if (eventModel.Amount <= 0) return BadRequest("Amount cannot be negative or equals to zero");

            var factory = _eventFactory.Create(eventModel.Type);
            var result = await factory.ExecuteEvent(eventModel);

            if (result is null) return NotFound(0);

            return Created(string.Empty, JsonSerializer.Deserialize<dynamic>(result));
        }
    }
}
