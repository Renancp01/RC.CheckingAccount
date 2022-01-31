using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RC.CheckingAccount.Domain.Commands.Credit;
using RC.CheckingAccount.Domain.Commom;
using RC.CheckingAccount.Domain.Entities;
using RC.CheckingAccount.Domain.Interfaces;
using RC.CheckingAccount.Domain.Interfaces.Core;
using RC.CheckingAccount.Domain.Notifications;

namespace RC.CheckingAccount.Domain.CommandsHandlers
{
    public class CreditCommandHandler : CommandHandler,
        IRequestHandler<CreateCreditCommand, bool>,
        IRequestHandler<UpdateCreditCommand, bool>,
        IRequestHandler<RemoveCreditCommand, bool>
    {

        private readonly ICreditRepository _creditRepository;
        private readonly IMediatorHandler _bus;

        public CreditCommandHandler(IMediatorHandler bus,
            ICreditRepository creditRepository,
            IUnitOfWork uow,
            INotificationHandler<DomainNotification> notifications) : base(bus, uow, notifications)
        {
            _bus = bus;
            _creditRepository = creditRepository;
        }

        public async Task<bool> Handle(CreateCreditCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return await Task.FromResult(false);
            }

            var credit = new Credit(Guid.NewGuid(), request.ClientId, request.Value);

            await _creditRepository.AddAsync(credit);

            if (await Commit())
            {
                // await _bus.RaiseEvent(new CreateClientEvent(client.Id, client.Name, client.LastName));
            }

            return await Task.FromResult(true);
        }

        public async Task<bool> Handle(UpdateCreditCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return await Task.FromResult(false);

            var credit = new Credit(request.Id, request.ClientId, request.Value);

            await _creditRepository.UpdateAsync(credit);

            if (await Commit())
            {
                //Send MassTransit
            }

            return await Task.FromResult(true);
        }

        public async Task<bool> Handle(RemoveCreditCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return await Task.FromResult(false);

            await _creditRepository.RemoveAsync(request.Id);

            if (await Commit())
            {
                //Send MassTransit
            }

            return await Task.FromResult(true);
        }
    }
}