using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using FluentValidation.Controllers;
using FluentValidation.Models;
using FluentValidation.WebApi;
using NUnit.Framework;
 


namespace Tests
{
    [TestFixture]
    class CustomerTest
    {
        [Test]
        public void Test()
        {

            var controller = new CustomerController();
            controller.Request = new HttpRequestMessage();
            var config = new HttpConfiguration();
            controller.Configuration = config;
            FluentValidationModelValidatorProvider.Configure(config);
            Customer customer = new Customer();
            customer.Name = "";


            var result = controller.Get(customer);

        }
    }
}
