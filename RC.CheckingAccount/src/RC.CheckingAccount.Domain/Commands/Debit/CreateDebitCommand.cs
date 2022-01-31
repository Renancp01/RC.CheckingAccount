using System;
using RC.CheckingAccount.Domain.Entities.Validators.Debit;

namespace RC.CheckingAccount.Domain.Commands.Debit
{
    public class CreateDebitCommand : DebitCommand
    {
        public CreateDebitCommand(Guid clientId, decimal value)
        {
            ClientId = clientId;
            Value = value;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateDebitValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}