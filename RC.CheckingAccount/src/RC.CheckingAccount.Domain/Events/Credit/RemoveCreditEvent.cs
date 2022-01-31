using System;
using RC.CheckingAccount.Domain.Commom;

namespace RC.CheckingAccount.Domain.Events.Credit
{
    public class RemoveCreditEvent : Event
    {
        public RemoveCreditEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}