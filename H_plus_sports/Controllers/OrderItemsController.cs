using System;
using System.Threading.Tasks;
using H_plus_sports.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace H_plus_sports.Controllers
{
    [Produces("application/json")]
    [Route("api/OrderItems")]
    public class OrderItemsController : Controller
    {
        private readonly H_Plus_SportsContext _context;
        public OrderItemsController(H_Plus_SportsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetOrderItem()
        {
            return new ObjectResult(_context.OrderItem);
        }

        [HttpGet("{id}", Name = "GetOrderItem")]
        public async Task<IActionResult> GetOrderItem([FromRoute] int id)
        {
            var orderItem = await _context.OrderItem.SingleOrDefaultAsync(c => c.OrderItemId == id);
            return Ok(orderItem);
        }

        [HttpPost]
        public async Task<IActionResult> PostOrderItem([FromBody] OrderItem orderItem)
        {
            _context.OrderItem.Add(orderItem);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetOrderItem", new { id = orderItem.OrderItemId }, orderItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderItem([FromRoute] int id, [FromBody] OrderItem orderItem)
        {
            _context.Entry(orderItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(orderItem);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem([FromRoute] int id)
        {
            var orderItem = await _context.OrderItem.SingleOrDefaultAsync(c => c.OrderItemId == id);
            _context.OrderItem.Remove(orderItem);
            await _context.SaveChangesAsync();
            return Ok(orderItem);
        }
    }
}