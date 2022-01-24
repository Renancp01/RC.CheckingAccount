using MediatR;

namespace RC.CheckingAccount.Domain.Commands.Client
{
    public class CreateClientCommand : IRequest<Entities.Client>
    {
        public string Name { get; private set; }

        public string LastName { get; private set; }

        public CreateClientCommand(string name, string lastname)
        {
            LastName = lastname;
            Name = name;
        }
    }
}