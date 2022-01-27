using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using RC.CheckingAccount.Domain.Commands.Client;
using RC.CheckingAccount.Domain.Interfaces.Core;
using RC.CheckingAccount.Domain.Notifications;

namespace RC.CheckingAccount.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckingAccountsController : CustomApiController
    {
        private IMediator _mediator;
        public CheckingAccountsController(DomainNotificationHandler notifications, IMediatorHandler mediatorHandler, IMediator mediator) : base(notifications, mediatorHandler)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(CreateClientCommand createClientCommand)
        {
            var client = await _mediator.Send(createClientCommand);

            //if (client is { IsValid: true })
            //    return BadRequest();

            return Response();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateClient([FromBody] UpdateClientCommand updateClientCommand)
        {
            var client = await _mediator.Send(updateClientCommand);

            //if (client is not { IsValid: true })
            //    return BadRequest();

            return Ok();
        }

        //[HttpPost]
        //public IEnumerable<string> Debit()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //[HttpGet]
        //public string Credit()
        //{
        //    return "value";
        //}
      
    }
}
