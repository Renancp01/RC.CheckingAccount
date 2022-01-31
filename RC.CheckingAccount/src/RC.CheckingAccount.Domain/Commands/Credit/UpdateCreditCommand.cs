using System;
using RC.CheckingAccount.Domain.Entities.Validators.Credit;

namespace RC.CheckingAccount.Domain.Commands.Credit
{
    public class UpdateCreditCommand : CreditCommand
    {
        public UpdateCreditCommand(Guid id, decimal value)
        {
            Id = id;
            Value = value;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateCreditValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}