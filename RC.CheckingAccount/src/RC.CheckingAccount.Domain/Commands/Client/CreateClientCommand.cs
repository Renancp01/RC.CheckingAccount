using RC.CheckingAccount.Domain.Entities.Validators.Client;

namespace RC.CheckingAccount.Domain.Commands.Client
{
    public class CreateClientCommand : ClientCommand
    {
        public CreateClientCommand(string name, string lastname)
        {
            Name = name;
            LastName = lastname;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateClientValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}