using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RC.CheckingAccount.Domain.Events.Client;

namespace RC.CheckingAccount.Domain.EventHandlers
{
    public class ClientEventHaldler : INotificationHandler<CreateClientEvent>,
                                      INotificationHandler<UpdateClientEvent>,
                                      INotificationHandler<RemoveClientEvent>
    {
        public Task Handle(CreateClientEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
            //throw new System.NotImplementedException();
        }

        public Task Handle(UpdateClientEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
            //throw new System.NotImplementedException();
        }

        public Task Handle(RemoveClientEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
            //throw new System.NotImplementedException();
        }
    }
}