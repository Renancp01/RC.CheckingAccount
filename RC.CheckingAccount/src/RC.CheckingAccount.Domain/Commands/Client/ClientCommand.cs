using System;
using RC.CheckingAccount.Domain.CommandsHandlers.Core;

namespace RC.CheckingAccount.Domain.Commands.Client
{
    public abstract class ClientCommand : Command
    {
        public Guid Id { get; set; }

        public string Name { get; protected set; }

        public string LastName { get; protected set; }
    }
}