using System;
using RC.CheckingAccount.Domain.CommandsHandlers.Core;

namespace RC.CheckingAccount.Domain.Events.Client
{
    public class CreateClientEvent : Event
    {
        public CreateClientEvent(Guid id, string name, string lastnaName)
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