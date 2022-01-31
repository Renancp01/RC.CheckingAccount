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
    public class CreditController : CustomApiController
    {
        private readonly ICreditAppService _creditAppService;

        public CreditController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediatorHandler, ICreditAppService creditAppService) : base(notifications, mediatorHandler)
        {
            _creditAppService = creditAppService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreditViewModel viewModel)
        {
            _creditAppService.Add(viewModel);

            return Response(viewModel);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] CreditViewModel viewModel)
        {
            _creditAppService.Add(viewModel);

            return Response(viewModel);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] CreditViewModel viewModel)
        {
            _creditAppService.Add(viewModel);

            return Response(viewModel);
        }
    }
}
