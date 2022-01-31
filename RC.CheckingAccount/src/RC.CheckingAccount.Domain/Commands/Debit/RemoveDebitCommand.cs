using System;
using RC.CheckingAccount.Domain.Entities.Validators.Debit;

namespace RC.CheckingAccount.Domain.Commands.Debit
{
    public class RemoveDebitCommand : DebitCommand
    {
        public RemoveDebitCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveDebitValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}