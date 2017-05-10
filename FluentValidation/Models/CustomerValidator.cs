using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation.Results;
using FluentValidation.Validators;

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
             RuleFor(x => x.Address).SetValidator(new AddressValidator());
            //RuleFor(x => x.Address.AddressLine1).NotEmpty();
            //RuleFor(x => x.Address.AddressLine2).NotEmpty().WithMessage("address2 bla bla");
            //RuleFor(x => x.Address.Postcode).NotEmpty();



            //.When(x => !string.IsNullOrEmpty(x.Address?.AddressLine1))
            //.WithMessage("PostCode can't be empty");
            RuleFor(x => x.Age).NotEmpty().Unless(x => string.IsNullOrEmpty(x.Name)).WithMessage("Age can't Empty");


        }

        private bool PostCodeNotEmpty(string postcode)
        {
            return string.IsNullOrEmpty(postcode);
        }
    }

    public class AddressValidator : AbstractValidator<Models.Address>
    {

        public AddressValidator()
        {
            RuleFor(x => x.Postcode).NotEmpty();
            RuleFor(x => x.AddressLine1).NotEmpty();
            RuleFor(x => x.AddressLine2).NotEmpty();
        }


    }

    public class CusotmerListValidator : AbstractValidator<CustomerList>
    {
        public CusotmerListValidator()
        {
            RuleFor(c => c.CustomerType).NotEmpty();
            RuleFor(c => c.Customers).SetValidator(new CustomerValidator());
            RuleFor(c => c.Customers.Address).SetValidator(new AddressValidator());
        }
    }


}