using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RC.CheckingAccount.Domain.Events.Credit;

namespace RC.CheckingAccount.Domain.EventHandlers
{
    public class CreditEventHandler :
                 INotificationHandler<CreateCreditEvent>,
                 INotificationHandler<UpdateCreditEvent>,
                 INotificationHandler<RemoveCreditEvent>
    {
        public Task Handle(CreateCreditEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task Handle(UpdateCreditEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task Handle(RemoveCreditEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}