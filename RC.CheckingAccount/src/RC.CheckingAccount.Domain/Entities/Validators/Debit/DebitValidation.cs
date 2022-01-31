using FluentValidation;
using RC.CheckingAccount.Domain.Commands.Debit;
using System;

namespace RC.CheckingAccount.Domain.Entities.Validators.Debit
{
    public class DebitValidation<T> : AbstractValidator<T> where T : DebitCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateClientId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateValue()
        {
            RuleFor(c => c.Value)
                .NotNull().WithMessage("Please ensure you have entered the Value")
                .GreaterThan(0).WithMessage("Debit amount must be greater than zero");
        }
    }
}