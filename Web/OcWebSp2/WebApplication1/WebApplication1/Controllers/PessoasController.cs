﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiWebSp.Models;
using WebApplication1.Context;

namespace ApiWebSp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PessoasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Pessoas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoas>>> GetPessoas()
        {
          if (_context.Pessoas == null)
          {
              return NotFound();
          }
            return await _context.Pessoas.ToListAsync();
        }

        // GET: api/Pessoas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoas>> GetPessoas(int id)
        {
          if (_context.Pessoas == null)
          {
              return NotFound();
          }
            var pessoas = await _context.Pessoas.FindAsync(id);

            if (pessoas == null)
            {
                return NotFound();
            }

            return pessoas;
        }

        // PUT: api/Pessoas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPessoas(int id, Pessoas pessoas)
        {
            if (id != pessoas.Id)
            {
                return BadRequest();
            }

            _context.Entry(pessoas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PessoasExists(id))
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

        // POST: api/Pessoas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pessoas>> PostPessoas(Pessoas pessoas)
        {
          if (_context.Pessoas == null)
          {
              return Problem("Entity set 'AppDbContext.Pessoas'  is null.");
          }
            _context.Pessoas.Add(pessoas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPessoas", new { id = pessoas.Id }, pessoas);
        }

        // DELETE: api/Pessoas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePessoas(int id)
        {
            if (_context.Pessoas == null)
            {
                return NotFound();
            }
            var pessoas = await _context.Pessoas.FindAsync(id);
            if (pessoas == null)
            {
                return NotFound();
            }

            _context.Pessoas.Remove(pessoas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PessoasExists(int id)
        {
            return (_context.Pessoas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
