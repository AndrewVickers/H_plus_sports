﻿using System;
using System.Threading.Tasks;
using H_plus_sports.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace H_plus_sports.Controllers
{
    [Produces("application/json")]
    [Route("api/Salespersons")]
    public class SalespersonsController : Controller
    {
        private readonly H_Plus_SportsContext _context;
        public SalespersonsController(H_Plus_SportsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetSalesperson()
        {
            return new ObjectResult(_context.Salesperson);
        }

        [HttpGet("{id}", Name = "GetSalesperson")]
        public async Task<IActionResult> GetSalesperson([FromRoute] int id)
        {
            var salesperson = await _context.Salesperson.SingleOrDefaultAsync(c => c.SalespersonId == id);
            return Ok(salesperson);
        }

        [HttpPost]
        public async Task<IActionResult> PostSalesperson([FromBody] Salesperson salesperson)
        {
            _context.Salesperson.Add(salesperson);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetSalesperson", new { id = salesperson.SalespersonId }, salesperson);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesperson([FromRoute] int id, [FromBody] Salesperson salesperson)
        {
            _context.Entry(salesperson).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(salesperson);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesperson([FromRoute] int id)
        {
            var salesperson = await _context.Salesperson.SingleOrDefaultAsync(c => c.SalespersonId == id);
            _context.Salesperson.Remove(salesperson);
            await _context.SaveChangesAsync();
            return Ok(salesperson);
        }
    }
}