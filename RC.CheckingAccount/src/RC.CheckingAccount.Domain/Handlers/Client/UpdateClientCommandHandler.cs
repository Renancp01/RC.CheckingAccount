using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RC.CheckingAccount.Domain.Commands.Client;
using RC.CheckingAccount.Domain.Interfaces;

namespace RC.CheckingAccount.Domain.Handlers.Client
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Entities.Client>
    {
        private readonly IClientRepository _clientRepository;

        public UpdateClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Entities.Client> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var user = new Entities.Client(request.Id, request.Name, request.LastName);

            if (user.IsValid)
                return user;

            await _clientRepository.UpdateAsync(user);

            return user;
        }
    }
}