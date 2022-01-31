using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RC.CheckingAccount.Domain.Events.Debit;

namespace RC.CheckingAccount.Domain.EventHandlers
{
    public class DebitEventHandler :
                 INotificationHandler<CreateDebitEvent>,
                 INotificationHandler<UpdateDebitEvent>,
                 INotificationHandler<RemoveDebitEvent>
    {
        public Task Handle(CreateDebitEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task Handle(UpdateDebitEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task Handle(RemoveDebitEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}