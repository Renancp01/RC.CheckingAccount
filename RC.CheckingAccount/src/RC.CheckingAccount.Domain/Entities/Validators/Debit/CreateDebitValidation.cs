using RC.CheckingAccount.Domain.Commands.Debit;

namespace RC.CheckingAccount.Domain.Entities.Validators.Debit
{
    public class CreateDebitValidation : DebitValidation<CreateDebitCommand>
    {
        public CreateDebitValidation()
        {
            ValidateClientId();
            ValidateValue();
        }
    }
}