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
    public class AvisosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AvisosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Avisos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Avisos>>> GetAvisos()
        {
          if (_context.Avisos == null)
          {
              return NotFound();
          }
            try
            {
                var retorno = await _context.Avisos.ToListAsync();
                return Ok(retorno);
            }
            catch (Exception ex)
            {

                throw;
            } 
        }

        // GET: api/Avisos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Avisos>> GetAvisos(int id)
        {
          if (_context.Avisos == null)
          {
              return NotFound();
          }
            var avisos = await _context.Avisos.FindAsync(id);

            if (avisos == null)
            {
                return NotFound();
            }

            return avisos;
        }

        // PUT: api/Avisos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAvisos(int id, Avisos avisos)
        {
            if (id != avisos.Id)
            {
                return BadRequest();
            }

            _context.Entry(avisos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvisosExists(id))
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

        // POST: api/Avisos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Avisos>> PostAvisos(Avisos avisos)
        {
          if (_context.Avisos == null)
          {
              return Problem("Entity set 'AppDbContext.Avisos'  is null.");
          }
            _context.Avisos.Add(avisos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAvisos", new { id = avisos.Id }, avisos);
        }

        // DELETE: api/Avisos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAvisos(int id)
        {
            if (_context.Avisos == null)
            {
                return NotFound();
            }
            var avisos = await _context.Avisos.FindAsync(id);
            if (avisos == null)
            {
                return NotFound();
            }

            _context.Avisos.Remove(avisos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AvisosExists(int id)
        {
            return (_context.Avisos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
