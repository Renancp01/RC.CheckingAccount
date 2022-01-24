using FluentValidation;

namespace RC.CheckingAccount.Domain.Entities.Validators
{
    public class CreditValidator : AbstractValidator<Credit>
    {
        public CreditValidator()
        {
            RuleFor(a => a.Value)
                .NotNull()
                .WithMessage("Value cannot be Null");
        }
    }
}