using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RC.CheckingAccount.Domain.Commands.Client;
using RC.CheckingAccount.Domain.Interfaces;

namespace RC.CheckingAccount.Domain.Handlers.Client
{
    public class RemoveClientCommandHandler : IRequestHandler<RemoveClientCommand>
    {
        private readonly IClientRepository _clientRepository;

        public RemoveClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Unit> Handle(RemoveClientCommand request, CancellationToken cancellationToken)
        {
            await _clientRepository.RemoveAsync(request.Id);
            
            return Unit.Value;
        }
    }
}