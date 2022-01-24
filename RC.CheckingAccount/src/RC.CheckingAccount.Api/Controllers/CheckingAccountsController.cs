using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using RC.CheckingAccount.Domain.Commands;
using RC.CheckingAccount.Domain.Commands.Client;

namespace RC.CheckingAccount.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckingAccountsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CheckingAccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(CreateClientCommand clientCommand)
        {
            var client = await _mediator.Send(clientCommand);

            if (client is not { IsValid: true })
                return BadRequest();

            return Ok(client);
        }

        [HttpPost]
        public IEnumerable<string> Debit()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        public string Credit()
        {
            return "value";
        }
    }
}
