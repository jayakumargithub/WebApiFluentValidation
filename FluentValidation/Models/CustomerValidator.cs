using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FluentValidation.Models
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Name).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("Name can not be empty.")
                .Length(4, 30)
                .WithMessage("Name must not be greater than 30 characters.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Not a valid email");
            RuleFor(x => x.Address).NotNull().WithMessage("Address can not be null");
            RuleFor(x => x.Address.Postcode)
                .NotEmpty()
                .When(x => !string.IsNullOrEmpty(x.Address?.AddressLine1))
                .WithMessage("PostCode can't be empty");
            RuleFor(x => x.Age).NotEmpty().Unless(x => string.IsNullOrEmpty(x.Name)).WithMessage("Age can't Empty");

        }
    }
}