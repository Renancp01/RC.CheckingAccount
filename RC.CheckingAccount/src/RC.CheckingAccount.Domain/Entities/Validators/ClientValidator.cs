using FluentValidation;

namespace RC.CheckingAccount.Domain.Entities.Validators
{
    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .WithMessage("Name cannot be empty");

            RuleFor(a => a.LastName)
                .NotEmpty()
                .WithMessage("Lastname cannot be empty");
        }
    }
}