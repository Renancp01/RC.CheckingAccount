using System;
using RC.CheckingAccount.Domain.Entities.Validators.Client;

namespace RC.CheckingAccount.Domain.Commands.Client
{
    public class RemoveClientCommand : ClientCommand
    {
        public RemoveClientCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveClientCommandValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}