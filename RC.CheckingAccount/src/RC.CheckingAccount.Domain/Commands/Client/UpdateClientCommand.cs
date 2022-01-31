using System;
using RC.CheckingAccount.Domain.Entities.Validators.Client;

namespace RC.CheckingAccount.Domain.Commands.Client
{
    public class UpdateClientCommand : ClientCommand
    {
        public UpdateClientCommand(Guid id, string name, string lastname)
        {
            Id = id;
            Name = name;
            LastName = lastname;
        }
      
        public override bool IsValid()
        {
            ValidationResult = new UpdateClientCommandValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}