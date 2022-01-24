using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RC.CheckingAccount.Domain.Commands.Client;
using RC.CheckingAccount.Domain.Interfaces;

namespace RC.CheckingAccount.Domain.Handlers.Client
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Entities.Client>
    {
        private readonly IClientRepository _clientRepository;

        public CreateClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Entities.Client> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var user = new Entities.Client(request.Name, request.LastName);

            if (user.IsValid)
                return user;

            await _clientRepository.AddAsync(user);

            return user;
        }
    }
}