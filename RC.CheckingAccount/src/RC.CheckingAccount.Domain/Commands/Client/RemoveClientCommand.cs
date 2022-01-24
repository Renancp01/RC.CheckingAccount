using System;
using MediatR;

namespace RC.CheckingAccount.Domain.Commands.Client
{
    public class RemoveClientCommand : IRequest
    {
        public Guid Id { get; set; }

        public RemoveClientCommand(Guid id)
        {
            Id = id;
        }
    }
}