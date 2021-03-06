using System;
using RC.CheckingAccount.Domain.Commom;

namespace RC.CheckingAccount.Domain.Events.Client
{
    public class UpdateClientEvent : Event
    {
        public UpdateClientEvent(Guid id, string name, string lastnaName)
        {
            Id = id;
            Name = name;
            LastName = lastnaName;
            AggregateId = id;
        }

        public Guid Id { get; set; }

        public string Name { get; private set; }

        public string LastName { get; private set; }
    }
}