using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using RC.CheckingAccount.Application.Interfaces;
using RC.CheckingAccount.Application.ViewModels;
using RC.CheckingAccount.Domain.Interfaces.Core;
using RC.CheckingAccount.Domain.Notifications;

namespace RC.CheckingAccount.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebitController : CustomApiController
    {
        private readonly IDebitAppService _debitAppService;

        public DebitController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediatorHandler, IDebitAppService debitAppService) : base(notifications, mediatorHandler)
        {
            _debitAppService = debitAppService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] DebitViewModel viewModel)
        {
            _debitAppService.Add(viewModel);

            return Response(viewModel);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] DebitViewModel viewModel)
        {
            _debitAppService.Add(viewModel);

            return Response(viewModel);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DebitViewModel viewModel)
        {
            _debitAppService.Add(viewModel);

            return Response(viewModel);
        }

    }
}
