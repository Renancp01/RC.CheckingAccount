using System;
using FluentValidation;
using FluentValidation.Results;

namespace RC.CheckingAccount.Domain.Entities.Base
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        public DateTimeOffset DateOfCreation { get; set; }

        public DateTimeOffset? DateOfModify { get; set; }

        public DateTimeOffset? DateOfExclusion { get; set; }

        public bool IsValid { get; private set; }

        public ValidationResult ValidationResult { get; private set; }

        public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            ValidationResult = validator.Validate(model);
            
            return IsValid = ValidationResult.IsValid;
        }
    }
}