using Microsoft.EntityFrameworkCore;
using OcWebSp.Data.Models;

namespace OcWebSp.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuarios>Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=ModuloWeb;User ID=sa;Password=sql2017;TrustServerCertificate=true");
        }
    }
}
