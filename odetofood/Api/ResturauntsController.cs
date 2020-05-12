using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using odotofood.core;
using odotofood.data;

namespace odetofood.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResturauntsController : ControllerBase
    {
        private readonly OdetofoodDBcontext _context;

        public ResturauntsController(OdetofoodDBcontext context)
        {
            _context = context;
        }

        // GET: api/Resturaunts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resturaunts>>> GetResturaunt()
        {
            return await _context.Resturaunt.ToListAsync();
        }

        // GET: api/Resturaunts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Resturaunts>> GetResturaunts(int id)
        {
            var resturaunts = await _context.Resturaunt.FindAsync(id);

            if (resturaunts == null)
            {
                return NotFound();
            }

            return resturaunts;
        }

        // PUT: api/Resturaunts/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResturaunts(int id, Resturaunts resturaunts)
        {
            if (id != resturaunts.ID)
            {
                return BadRequest();
            }

            _context.Entry(resturaunts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResturauntsExists(id))
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

        // POST: api/Resturaunts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Resturaunts>> PostResturaunts(Resturaunts resturaunts)
        {
            _context.Resturaunt.Add(resturaunts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResturaunts", new { id = resturaunts.ID }, resturaunts);
        }

        // DELETE: api/Resturaunts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Resturaunts>> DeleteResturaunts(int id)
        {
            var resturaunts = await _context.Resturaunt.FindAsync(id);
            if (resturaunts == null)
            {
                return NotFound();
            }

            _context.Resturaunt.Remove(resturaunts);
            await _context.SaveChangesAsync();

            return resturaunts;
        }

        private bool ResturauntsExists(int id)
        {
            return _context.Resturaunt.Any(e => e.ID == id);
        }
    }
}
