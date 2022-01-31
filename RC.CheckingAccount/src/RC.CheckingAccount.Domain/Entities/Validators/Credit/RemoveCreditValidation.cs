using RC.CheckingAccount.Domain.Commands.Credit;

namespace RC.CheckingAccount.Domain.Entities.Validators.Credit
{
    public class RemoveCreditValidation : CreditValidation<RemoveCreditCommand>
    {
        public RemoveCreditValidation()
        {
            ValidateId();
        }
    }
}