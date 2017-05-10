using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation.Attributes;

namespace FluentValidation.Models
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
        public string AddressLine2 { get; set; }
        public string Postcode { get; set; }
    }


    //[Validator(typeof(CusotmerListValidator))]
    public class CustomerList
    {
        public string CustomerType { get; set; }
        public Customer Customers { get; set; }
        
    }
}