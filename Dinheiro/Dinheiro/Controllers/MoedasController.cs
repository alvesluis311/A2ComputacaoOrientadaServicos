using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dinheiro.Models;

namespace Dinheiro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoedasController : ControllerBase
    {
        private readonly DinheirodbContext _context;

        public MoedasController(DinheirodbContext context)
        {
            _context = context;
        }

        // GET: api/Moedas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Moeda>>> GetMoeda()
        {
            return await _context.Moeda.ToListAsync();
        }

        // GET: api/Moedas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Moeda>> GetMoeda(long? id)
        {
            var moeda = await _context.Moeda.FindAsync(id);

            if (moeda == null)
            {
                return NotFound();
            }

            return moeda;
        }

        // PUT: api/Moedas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMoeda(long? id, Moeda moeda)
        {
            if (id != moeda.Id)
            {
                return BadRequest();
            }

            _context.Entry(moeda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoedaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Moedas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Moeda>> PostMoeda(Moeda moeda)
        {
            _context.Moeda.Add(moeda);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMoeda", new { id = moeda.Id }, moeda);
        }

        // DELETE: api/Moedas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMoeda(long? id)
        {
            var moeda = await _context.Moeda.FindAsync(id);
            if (moeda == null)
            {
                return NotFound();
            }

            _context.Moeda.Remove(moeda);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MoedaExists(long? id)
        {
            return _context.Moeda.Any(e => e.Id == id);
        }
    }
}
