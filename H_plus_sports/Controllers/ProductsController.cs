using System;
using System.Threading.Tasks;
using H_plus_sports.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace H_plus_sports.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        private readonly H_Plus_SportsContext _context;
        public ProductsController(H_Plus_SportsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetProduct()
        {
            return new ObjectResult(_context.Product);
        }

        [HttpGet("{id}", Name= "GetProduct")]
        public async Task<IActionResult> GetProduct([FromRoute] string id)
        {
            var product = await _context.Product.SingleOrDefaultAsync(c => c.ProductId == id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct([FromBody] Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct([FromRoute] string id, [FromBody] Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] string id)
        {
            var product = await _context.Product.SingleOrDefaultAsync(c => c.ProductId == id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }
    }
}