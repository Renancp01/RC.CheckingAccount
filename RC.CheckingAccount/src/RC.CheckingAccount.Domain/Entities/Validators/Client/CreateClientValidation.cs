using RC.CheckingAccount.Domain.Commands.Client;

namespace RC.CheckingAccount.Domain.Entities.Validators.Client
{
    public class CreateClientValidation : ClientValidation<CreateClientCommand>
    {
        public CreateClientValidation()
        {
            ValidateName();
            ValidateLastName();
        }
    }
}