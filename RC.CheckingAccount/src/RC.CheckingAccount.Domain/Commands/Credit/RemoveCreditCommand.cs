using System;
using RC.CheckingAccount.Domain.Entities.Validators.Credit;

namespace RC.CheckingAccount.Domain.Commands.Credit
{
    public class RemoveCreditCommand : CreditCommand
    {
        public RemoveCreditCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveCreditValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}