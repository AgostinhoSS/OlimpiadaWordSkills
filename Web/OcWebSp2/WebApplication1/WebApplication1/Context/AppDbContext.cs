using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using ApiWebSp.Models;

namespace WebApplication1.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cursos> Cursos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=ModuloWeb;User ID=sa;Password=sql2017;TrustServerCertificate=true");
        }

        public DbSet<ApiWebSp.Models.Turmas>? Turmas { get; set; }

        public DbSet<ApiWebSp.Models.Alunos>? Alunos { get; set; }

        public DbSet<ApiWebSp.Models.Usuarios>? Usuarios { get; set; }

        public DbSet<ApiWebSp.Models.Pessoas>? Pessoas { get; set; }

        public DbSet<ApiWebSp.Models.Docentes>? Docentes { get; set; }

        public DbSet<ApiWebSp.Models.Avisos>? Avisos { get; set; }
    }
}
