using System;
using MediatR;

namespace RC.CheckingAccount.Domain.CommandsHandlers.Core
{
    public abstract class Message : IRequest<bool>
    {
        public string MessageType { get; protected set; }

        public Guid AggregateId { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}