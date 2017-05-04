using FluentValidation;

namespace WebApiFluentValidation.Models
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name can not be empty.")
                .Length(0, 30)
                .WithMessage("Name must not be greater than 30 characters.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Not a valid email");
            RuleFor(x => x.Address.Postcode)
                .NotEmpty()
                .When(x => !string.IsNullOrEmpty(x.Address?.AddressLine1))
                .WithMessage("PostCode can't be empty");
            RuleFor(x => x.Age).NotEmpty().Unless(x => string.IsNullOrEmpty(x.Name)).WithMessage("Age can't Empty");

        }
    }
}