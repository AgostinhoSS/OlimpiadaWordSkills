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
    [Route("api/")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Pessoas
        [HttpGet("Pessoas")]
        public async Task<ActionResult<IEnumerable<Pessoas>>> GetPessoas()
        {
            if (_context.Pessoas == null)
            {
                return NotFound();
            }

            

            return await _context.Pessoas.ToListAsync();
        }

        // GET: api/Pessoas/5
        [HttpGet("Pessoas/{id}")]
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
        [HttpPut("Pessoas/{id}")]
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
        [HttpPost("Pessoas")]
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
        [HttpDelete("Pessoas/{id}")]
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

        // GET: api/Usuarios
        [HttpGet("Usuarios")]
        public async Task<ActionResult<IEnumerable<Usuarios>>> GetUsuarios()
        {
            if (_context.Usuarios == null)
            {
                return NotFound();
            }
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("Usuarios/{id}")]
        public async Task<ActionResult<Usuarios>> GetUsuarios(int id)
        {
            if (_context.Usuarios == null)
            {
                return NotFound();
            }
            var usuarios = await _context.Usuarios.FindAsync(id);

            if (usuarios == null)
            {
                return NotFound();
            }

            return usuarios;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Usuarios/{id}")]
        public async Task<IActionResult> PutUsuarios(int id, Usuarios usuarios)
        {
            if (id != usuarios.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuarios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuariosExists(id))
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

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Usuarios")]
        public async Task<ActionResult<Usuarios>> PostUsuarios(Usuarios usuarios)
        {
            if (_context.Usuarios == null)
            {
                return Problem("Entity set 'AppDbContext.Usuarios'  is null.");
            }
            _context.Usuarios.Add(usuarios);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarios", new { id = usuarios.Id }, usuarios);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("Usuarios/{id}")]
        public async Task<IActionResult> DeleteUsuarios(int id)
        {
            if (_context.Usuarios == null)
            {
                return NotFound();
            }
            var usuarios = await _context.Usuarios.FindAsync(id);
            if (usuarios == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuarios);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuariosExists(int id)
        {
            return (_context.Usuarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // GET: api/Login/5
        [HttpGet("Usuarios/{email}/{senha}")]
        public async Task<ActionResult<Perfil>> GetLogin(string email, string senha)
        {
            var usuarios = await _context.Usuarios.Where(x => x.Senha == senha).FirstOrDefaultAsync();
            var pessoas = await _context.Pessoas.Where(x => x.Email == email).FirstOrDefaultAsync();
            int idUsu = usuarios.Id;
            var alunos = await _context.Alunos.Where(x => x.Id == idUsu).FirstOrDefaultAsync<Aluno>();
            var docentes = await _context.Docentes.Where(x => x.Id == idUsu).FirstOrDefaultAsync<Docentes>();
            Perfil perfil;
            if (usuarios.Id == pessoas.Id)
            {
                if (alunos != null)
                {
                    perfil = new Perfil()
                    {
                        Id = idUsu,
                        Name = pessoas.Nome,
                        Tipo = "Aluno",
                    };

                }
                else
                {
                    perfil = new Perfil()
                    {
                        Id = idUsu,
                        Name = pessoas.Nome,
                        Tipo = "Docente",
                    };
                }
            }
            else
            {
                return null;
            }
            return perfil;
        }
    }
}
