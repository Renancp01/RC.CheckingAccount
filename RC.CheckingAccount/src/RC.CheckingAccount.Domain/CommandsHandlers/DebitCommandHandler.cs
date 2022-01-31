using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RC.CheckingAccount.Domain.Commands.Debit;
using RC.CheckingAccount.Domain.Commom;
using RC.CheckingAccount.Domain.Entities;
using RC.CheckingAccount.Domain.Interfaces;
using RC.CheckingAccount.Domain.Interfaces.Core;
using RC.CheckingAccount.Domain.Notifications;

namespace RC.CheckingAccount.Domain.CommandsHandlers
{
    public class DebitCommandHandler : CommandHandler,
                 IRequestHandler<CreateDebitCommand, bool>,
                 IRequestHandler<UpdateDebitCommand, bool>,
                 IRequestHandler<RemoveDebitCommand, bool>
    {
        private readonly IDebitRepository _debitRepository;
        private readonly IMediatorHandler _bus;

        public DebitCommandHandler(IMediatorHandler bus,
            IDebitRepository debitRepository,
            IUnitOfWork uow,
            INotificationHandler<DomainNotification> notifications) : base(bus, uow, notifications)
        {
            _bus = bus;
            _debitRepository = debitRepository;
        }

        public async Task<bool> Handle(CreateDebitCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return await Task.FromResult(false);
            }

            var credit = new Debit(Guid.NewGuid(), request.ClientId, request.Value);

            await _debitRepository.AddAsync(credit);

            if (await Commit())
            {
                // await _bus.RaiseEvent(new CreateClientEvent(client.Id, client.Name, client.LastName));
            }

            return await Task.FromResult(true);
        }

        public async Task<bool> Handle(UpdateDebitCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return await Task.FromResult(false);

            var credit = new Debit(request.Id, request.ClientId, request.Value);

            await _debitRepository.UpdateAsync(credit);

            if (await Commit())
            {
                //Send MassTransit
            }

            return await Task.FromResult(true);
        }

        public async Task<bool> Handle(RemoveDebitCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return await Task.FromResult(false);

            await _debitRepository.RemoveAsync(request.Id);

            if (await Commit())
            {
                //Send MassTransit
            }

            return await Task.FromResult(true);
        }
    }
}