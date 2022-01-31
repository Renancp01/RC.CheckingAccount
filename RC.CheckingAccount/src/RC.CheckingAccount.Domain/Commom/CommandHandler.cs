using System.Threading.Tasks;
using MediatR;
using RC.CheckingAccount.Domain.Interfaces;
using RC.CheckingAccount.Domain.Interfaces.Core;
using RC.CheckingAccount.Domain.Notifications;

namespace RC.CheckingAccount.Domain.Commom
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMediatorHandler _bus;
        private readonly DomainNotificationHandler _notifications;

        public CommandHandler(IMediatorHandler bus, IUnitOfWork uow, INotificationHandler<DomainNotification> notifications)
        {
            _bus = bus;
            _uow = uow;
            _notifications = (DomainNotificationHandler)notifications;
        }
   

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                //_bus.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
            }
        }

        public async Task<bool> Commit()
        {
            if (_notifications.HasNotifications()) 
                return false;

            return await _uow.Commit();

            //_bus.RaiseEvent(new DomainNotification("Commit", "We had a problem during saving your data."));
        }
    }
}