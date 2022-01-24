using System;
using MediatR;

namespace RC.CheckingAccount.Domain.Commands.Client
{
    public class UpdateClientCommand : IRequest<Entities.Client>
    {
        public Guid Id { get; set; }

        public string Name { get; private set; }

        public string LastName { get; private set; }

        public UpdateClientCommand(Guid id, string name, string lastname)
        {
            Id = id;
            LastName = lastname;
            Name = name;
        }
    }
}