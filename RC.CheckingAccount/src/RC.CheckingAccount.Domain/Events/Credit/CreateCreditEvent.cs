using System;
using RC.CheckingAccount.Domain.Commom;

namespace RC.CheckingAccount.Domain.Events.Credit
{
    public class CreateCreditEvent : Event
    {
        public CreateCreditEvent(Guid id, Guid clientId, decimal value)
        {
            Id = id;
            Value = value;
            ClientId = clientId;
            AggregateId = id;
        }

        public Guid Id { get; set; }

        public Guid ClientId { get; set; }

        public decimal Value { get; private set; }
    }
}