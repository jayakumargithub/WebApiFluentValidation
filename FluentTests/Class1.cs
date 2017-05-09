using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Http;
using FluentValidation.Controllers;
using FluentValidation.Models;
using NUnit.Framework; 
using FluentValidation;
using FluentValidation.TestHelper;
using FluentValidation.WebApi;

namespace FluentTests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Test()
        {

            var customerValidator = new CustomerValidator();
            var customer = new Customer();
         var d =    customerValidator.ShouldHaveValidationErrorFor(c => c.Address, customer);

           
            Assert.AreEqual(d, "Address can not be null");

        }
    }
}
