using RC.CheckingAccount.Domain.Commands.Credit;

namespace RC.CheckingAccount.Domain.Entities.Validators.Credit
{
    public class UpdateCreditValidation : CreditValidation<UpdateCreditCommand>
    {
        public UpdateCreditValidation()
        {
            ValidateId();
            ValidateValue();
        }
    }
}