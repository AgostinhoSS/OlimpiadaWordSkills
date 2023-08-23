using ApiWebSp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Context;

namespace ApiWebSp.Controllers
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
        [HttpGet("login/{email}/{senha}")]
        public async Task<ActionResult<Perfil>> GetPerfil(string email, string senha)
        {
            var usuario = _context.Usuarios.Where(x => x.Senha == senha).FirstOrDefault();
            var pessoa = _context.Pessoas.Where(x => x.Email == email).FirstOrDefault();
            if (pessoa is null)
            {
                Perfil perfil = new Perfil() { Mensagem = "Login Incorreto!" };
                return NotFound(perfil);
            }
            else
            {
                if (usuario is null)
                {
                    Perfil perfil = new Perfil() { Mensagem = "Senha Incorreta!" };
                    return NotFound(perfil);
                }
                else
                {
                    Perfil perfilLogado = new Perfil()
                    {
                        Id = usuario.Id,
                        Name = pessoa.Nome,
                    };
                    int contAluno = _context.Alunos.Where(x => x.Id == usuario.Id).Count();
                    int contDocente = _context.Docentes.Where(x => x.Id == usuario.Id).Count();

                    if (contAluno != 0)
                    {
                        perfilLogado.Tipo = "Aluno";
                        return perfilLogado;
                    }
                    else
                    {
                        if (contDocente != 0)
                        {
                            perfilLogado.Tipo = "Docente";
                            return perfilLogado;
                        }
                    }
                }
            }
            return BadRequest(null);
        }
    }
}
