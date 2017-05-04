using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation.Attributes;

namespace WebApiFluentValidation.Models
{
    [Validator(typeof(CustomerValidator))]
    public class Customer
    {
        
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Dob { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        

    }

    public class Address
    {
        public string AddressLine1 { get; set; }
        public string Postcode { get; set; }
    }
}                                                                