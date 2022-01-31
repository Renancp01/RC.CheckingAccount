using System;
using FluentValidation;
using RC.CheckingAccount.Domain.Commands.Credit;

namespace RC.CheckingAccount.Domain.Entities.Validators.Credit
{
    public class CreditValidation<T> : AbstractValidator<T> where T : CreditCommand
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
                .GreaterThan(0).WithMessage("Credit amount must be greater than zero");
        }
    }
}