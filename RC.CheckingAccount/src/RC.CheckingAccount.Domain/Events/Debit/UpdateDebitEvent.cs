using System;
using RC.CheckingAccount.Domain.Commom;

namespace RC.CheckingAccount.Domain.Events.Debit
{
    public class UpdateDebitEvent : Event
    {
        public UpdateDebitEvent(Guid id, Guid clientId, decimal value)
        {
            Id = id;
            ClientId = clientId;
            Value = value;
            AggregateId = id;
        }

        public Guid Id { get; set; }

        public Guid ClientId { get; set; }

        public decimal Value { get; private set; }
    }
}