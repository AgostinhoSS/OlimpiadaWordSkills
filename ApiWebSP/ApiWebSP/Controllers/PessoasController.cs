using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ApiWebSP.Models;

namespace ApiWebSP.Controllers
{
    [RoutePrefix("api/pessoas")]
    public class PessoasController : ApiController
    {
        private Model1 db = new Model1();

        [ResponseType(typeof(Pessoas))]
        public async Task<IHttpActionResult> GetById(int id)
        {
            Pessoas pessoas = await db.Pessoas.FindAsync(id);
            if (pessoas == null)
            {
                return NotFound();
            }

            return Ok(pessoas);
        }

        [HttpGet]
        [Route("login")]
        public async Task<IHttpActionResult> Login([FromUri] string email, string senha)
        {
            Perfil perfil = new Perfil();

            Pessoas pessoas = await db.Pessoas.Where(x => x.Email == email).FirstOrDefaultAsync();
            if (pessoas is null)
            {
                perfil.Mensagem = "Usuário não encontrado";
                perfil.Erro = true;
                return Ok(perfil);
            }
            Usuarios usuarios = await db.Usuarios.Where(x => x.Senha == senha).FirstOrDefaultAsync();
            if (usuarios is null)
            {
                perfil.Mensagem = "Senha Incorreta";
                perfil.Erro = true;
                return Ok(perfil);
            }
            Docentes docente = await db.Docentes.Where(x => x.Id == pessoas.Id).FirstOrDefaultAsync();
            if (docente != null)
            {
                perfil.IdPerfil = pessoas.Id;
                perfil.Nome = pessoas.Nome;
                perfil.Tipo = "Docente";
                return Ok(perfil);
            }
            Alunos aluno = await db.Alunos.Where(x => x.Id == pessoas.Id).FirstOrDefaultAsync();

            if (aluno != null)
            {
                perfil.IdPerfil = pessoas.Id;
                perfil.Nome = pessoas.Nome;
                perfil.Tipo = "Aluno";
                return Ok(perfil);
            }
            return BadRequest();
        }

        // GET: api/Pessoas
        public IQueryable<Pessoas> GetPessoas()
        {
            return db.Pessoas;
        }

        // GET: api/Pessoas/5
        [ResponseType(typeof(Pessoas))]
        public async Task<IHttpActionResult> GetPessoas(int id)
        {
            Pessoas pessoas = await db.Pessoas.FindAsync(id);
            if (pessoas == null)
            {
                return NotFound();
            }

            return Ok(pessoas);
        }

        // PUT: api/Pessoas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPessoas(int id, Pessoas pessoas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pessoas.Id)
            {
                return BadRequest();
            }

            db.Entry(pessoas).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
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

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Pessoas
        [ResponseType(typeof(Pessoas))]
        public async Task<IHttpActionResult> PostPessoas(Pessoas pessoas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pessoas.Add(pessoas);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = pessoas.Id }, pessoas);
        }

        // DELETE: api/Pessoas/5
        [ResponseType(typeof(Pessoas))]
        public async Task<IHttpActionResult> DeletePessoas(int id)
        {
            Pessoas pessoas = await db.Pessoas.FindAsync(id);
            if (pessoas == null)
            {
                return NotFound();
            }

            db.Pessoas.Remove(pessoas);
            await db.SaveChangesAsync();

            return Ok(pessoas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PessoasExists(int id)
        {
            return db.Pessoas.Count(e => e.Id == id) > 0;
        }
    }
}