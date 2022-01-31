using RC.CheckingAccount.Domain.Commands.Debit;

namespace RC.CheckingAccount.Domain.Entities.Validators.Debit
{
    public class UpdateDebitValidation : DebitValidation<UpdateDebitCommand>
    {
        public UpdateDebitValidation()
        {
            ValidateId();
            ValidateValue();
        }
    }
}