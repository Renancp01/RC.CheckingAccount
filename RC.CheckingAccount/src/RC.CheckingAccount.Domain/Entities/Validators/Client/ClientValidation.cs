using System;
using FluentValidation;
using RC.CheckingAccount.Domain.Commands.Client;

namespace RC.CheckingAccount.Domain.Entities.Validators.Client
{
    public class ClientValidation<T> : AbstractValidator<T> where T : ClientCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateLastName()
        {
            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }
    }
}