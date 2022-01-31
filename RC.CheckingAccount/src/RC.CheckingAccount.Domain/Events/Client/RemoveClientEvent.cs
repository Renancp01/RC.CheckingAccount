using System;
using RC.CheckingAccount.Domain.Commom;

namespace RC.CheckingAccount.Domain.Events.Client
{
    public class RemoveClientEvent : Event
    {
        public RemoveClientEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; private set; }
    }
}