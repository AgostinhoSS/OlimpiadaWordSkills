using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OcWebSp.Data.Context;
using OcWebSp.Data.Models;

namespace OcWebSp.Data.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocentesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DocentesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Docentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Docentes>>> GetDocentes()
        {
            try
            {
                if (_context.Docentes == null)
                {
                    return NotFound();
                }
                return await _context.Docentes.ToListAsync();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        // GET: api/Docentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Docentes>> GetDocentes(int id)
        {
          if (_context.Docentes == null)
          {
              return NotFound();
          }
            var docentes = await _context.Docentes.FindAsync(id);

            if (docentes == null)
            {
                return NotFound();
            }

            return docentes;
        }

        // PUT: api/Docentes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocentes(int id, Docentes docentes)
        {
            if (id != docentes.Id)
            {
                return BadRequest();
            }

            _context.Entry(docentes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocentesExists(id))
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

        // POST: api/Docentes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Docentes>> PostDocentes(Docentes docentes)
        {
          if (_context.Docentes == null)
          {
              return Problem("Entity set 'AppDbContext.Docentes'  is null.");
          }
            _context.Docentes.Add(docentes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDocentes", new { id = docentes.Id }, docentes);
        }

        // DELETE: api/Docentes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocentes(int id)
        {
            if (_context.Docentes == null)
            {
                return NotFound();
            }
            var docentes = await _context.Docentes.FindAsync(id);
            if (docentes == null)
            {
                return NotFound();
            }

            _context.Docentes.Remove(docentes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DocentesExists(int id)
        {
            return (_context.Docentes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
