using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace RC.CheckingAccount.Domain.Notifications
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {

        private List<DomainNotification> _notifications;

        public DomainNotificationHandler(List<DomainNotification> notifications)
        {
            _notifications = notifications;
        }

        public Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        {
            _notifications.Add(notification);

            return Task.CompletedTask;
        }

        public virtual List<DomainNotification> GetNotifications()
        {
            return _notifications;
        }

        public virtual bool HasNotifications()
        {
            return GetNotifications().Any();
        }

        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
        }
    }
}