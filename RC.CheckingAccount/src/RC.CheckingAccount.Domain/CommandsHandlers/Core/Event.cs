using System;
using MediatR;

namespace RC.CheckingAccount.Domain.CommandsHandlers.Core
{
    public class Event : Message, INotification
    {
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}