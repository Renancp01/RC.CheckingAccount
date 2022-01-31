using System;
using RC.CheckingAccount.Domain.Entities.Validators.Debit;

namespace RC.CheckingAccount.Domain.Commands.Debit
{
    public class UpdateDebitCommand : DebitCommand
    {
        public UpdateDebitCommand(Guid id, decimal value)
        {
            Id = id;
            Value = value;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateDebitValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}