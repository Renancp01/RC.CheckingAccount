using System;
using RC.CheckingAccount.Domain.Entities.Base;

namespace RC.CheckingAccount.Domain.Entities
{
    public class Debit : Entity
    {
        public Debit(Guid id, Guid clientId, decimal value)
        {
            Id = id;
            ClientId = clientId;
            Value = value;
        }

        public Guid ClientId { get; set; }

        public decimal Value { get; set; }
    }
}
