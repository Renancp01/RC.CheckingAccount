using RC.CheckingAccount.Domain.Commands.Credit;

namespace RC.CheckingAccount.Domain.Entities.Validators.Credit
{
    public class CreateCreditValidation : CreditValidation<CreditCommand>
    {
        public CreateCreditValidation()
        {
            ValidateClientId();
            ValidateValue();
        }
    }
}