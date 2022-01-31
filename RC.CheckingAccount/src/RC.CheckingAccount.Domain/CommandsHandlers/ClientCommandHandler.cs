using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RC.CheckingAccount.Domain.Commands.Client;
using RC.CheckingAccount.Domain.Commom;
using RC.CheckingAccount.Domain.Entities;
using RC.CheckingAccount.Domain.Events.Client;
using RC.CheckingAccount.Domain.Interfaces;
using RC.CheckingAccount.Domain.Interfaces.Core;
using RC.CheckingAccount.Domain.Notifications;

namespace RC.CheckingAccount.Domain.CommandsHandlers
{
    public class ClientCommandHandler : CommandHandler,
        IRequestHandler<CreateClientCommand, bool>,
        IRequestHandler<RemoveClientCommand, bool>,
        IRequestHandler<UpdateClientCommand, bool>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMediatorHandler _bus;

        public ClientCommandHandler(
            IMediatorHandler bus,
            IClientRepository clientRepository,
            IUnitOfWork uow,
            INotificationHandler<DomainNotification> notifications)
            : base(bus, uow, notifications)
        {
            _bus = bus;
            _clientRepository = clientRepository;
        }

        public async Task<bool> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return await Task.FromResult(false);
            }

            var client = new Client(request.Id, request.Name, request.LastName);

            await _clientRepository.AddAsync(client);

            if (await Commit())
            {
                await _bus.RaiseEvent(new CreateClientEvent(client.Id, client.Name, client.LastName));
            }

            return await Task.FromResult(true);
        }

        public async Task<bool> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return await Task.FromResult(false);

            var client = new Client(request.Name, request.LastName);

            await _clientRepository.UpdateAsync(client);

            if (await Commit())
            {
                //Send MassTransit
            }

            return await Task.FromResult(true);
        }

        public async Task<bool> Handle(RemoveClientCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return await Task.FromResult(false);

            await _clientRepository.RemoveAsync(request.Id);

            if (await Commit())
            {
                //Send MassTransit
            }

            return await Task.FromResult(true);
        }
    }
}