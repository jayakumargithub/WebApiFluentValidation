using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiFluentValidation.Models;

namespace WebApiFluentValidation.Controllers
{
    public class CustomerController : ApiController
    {
        public IHttpActionResult Get([FromUri]Customer customer)
        {
            if (ModelState.IsValid)
            {
                return BadRequest();
            }
           
                return Ok();
             
        }
    }
}
