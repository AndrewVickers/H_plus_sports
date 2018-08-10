using System;
using Microsoft.AspNetCore.Mvc;

namespace H_plus_sports.Controllers
{
    [Produces("application/json")]
    [Route("api/Customers")]
    public class CustomersController : Controller
    {
        public CustomersController()
        {
            
        }

        [HttpGet]
        public IActionResult GetCustomer()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomer([FromRoute] int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult PostCustomer([FromBody] Object obj)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult PutCustomer([FromRoute] int id, [FromBody] Object obj)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer([FromRoute] int id)
        {
            return Ok();
        }
    }
}