using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RC.CheckingAccount.Application.Interfaces;
using RC.CheckingAccount.Application.ViewModels;
using RC.CheckingAccount.Domain.Interfaces.Core;
using RC.CheckingAccount.Domain.Notifications;

namespace RC.CheckingAccount.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : CustomApiController
    {
        private readonly IClientAppService _clientAppService;
        public ClientsController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediatorHandler, IMediator mediator, IClientAppService clientAppService) : base(notifications, mediatorHandler)
        {
            _clientAppService = clientAppService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] ClientViewModel viewModel)
        {
            await _clientAppService.Add(viewModel);

            return Response(viewModel);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] ClientViewModel viewModel)
        {
            _clientAppService.Update(viewModel);

            return Response(viewModel);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] ClientViewModel viewModel)
        {
           await _clientAppService.Remove(viewModel);

            return Response(viewModel);
        }

    }
}
