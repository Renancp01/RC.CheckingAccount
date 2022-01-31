using System;
using RC.CheckingAccount.Domain.Entities.Validators.Credit;

namespace RC.CheckingAccount.Domain.Commands.Credit
{
    public class CreateCreditCommand : CreditCommand
    {
        public CreateCreditCommand(Guid clientId, decimal value)
        {
            ClientId = clientId;
            Value = value;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateCreditValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}