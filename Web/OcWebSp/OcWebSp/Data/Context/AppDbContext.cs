using Microsoft.EntityFrameworkCore;
using OcWebSp.Data.Models;

namespace OcWebSp.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cursos> Cursos { get; set; }
        public DbSet<Turmas> Turmas { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Pessoas> Pessoas { get; set; }
        public DbSet<Docentes> Docentes { get; set; }
        public DbSet<Avisos> Avisos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=ModuloWeb;User ID=sa;Password=sql2017;TrustServerCertificate=true");
        }


    }
}
