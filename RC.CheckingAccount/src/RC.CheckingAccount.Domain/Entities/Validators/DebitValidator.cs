using FluentValidation;

namespace RC.CheckingAccount.Domain.Entities.Validators
{
    public class DebitValidator : AbstractValidator<Debit>
    {
        public DebitValidator()
        {
            RuleFor(a => a.Value)
                .NotNull()
                .WithMessage("Value cannot be Null");
        }
    }
}