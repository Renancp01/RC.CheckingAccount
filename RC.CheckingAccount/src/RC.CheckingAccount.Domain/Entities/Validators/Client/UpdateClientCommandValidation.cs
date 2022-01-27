using RC.CheckingAccount.Domain.Commands.Client;

namespace RC.CheckingAccount.Domain.Entities.Validators.Client
{
    public class UpdateClientCommandValidation : ClientValidation<UpdateClientCommand>
    {
        public UpdateClientCommandValidation()
        {
            ValidateId();
            ValidateName();
            ValidateLastName();
        }
    }
}