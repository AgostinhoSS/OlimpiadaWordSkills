using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ApiWebSP.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<AlunoModulo> AlunoModulo { get; set; }
        public virtual DbSet<Alunos> Alunos { get; set; }
        public virtual DbSet<Areas> Areas { get; set; }
        public virtual DbSet<Avisos> Avisos { get; set; }
        public virtual DbSet<CursoModulo> CursoModulo { get; set; }
        public virtual DbSet<Cursos> Cursos { get; set; }
        public virtual DbSet<Docentes> Docentes { get; set; }
        public virtual DbSet<Escolaridades> Escolaridades { get; set; }
        public virtual DbSet<Modulos> Modulos { get; set; }
        public virtual DbSet<Pessoas> Pessoas { get; set; }
        public virtual DbSet<TiposAtividade> TiposAtividade { get; set; }
        public virtual DbSet<TurmaAluno> TurmaAluno { get; set; }
        public virtual DbSet<Turmas> Turmas { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlunoModulo>()
                .Property(e => e.Observacao)
                .IsUnicode(false);

            modelBuilder.Entity<Alunos>()
                .HasMany(e => e.TurmaAluno)
                .WithOptional(e => e.Alunos)
                .HasForeignKey(e => e.IdAluno);

            modelBuilder.Entity<Areas>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Areas>()
                .HasMany(e => e.Cursos)
                .WithOptional(e => e.Areas)
                .HasForeignKey(e => e.IdArea);

            modelBuilder.Entity<Avisos>()
                .Property(e => e.Titulo)
                .IsUnicode(false);

            modelBuilder.Entity<Avisos>()
                .Property(e => e.Aviso)
                .IsUnicode(false);

            modelBuilder.Entity<Avisos>()
                .Property(e => e.Imagem)
                .IsUnicode(false);

            modelBuilder.Entity<CursoModulo>()
                .Property(e => e.Status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CursoModulo>()
                .HasMany(e => e.AlunoModulo)
                .WithOptional(e => e.CursoModulo)
                .HasForeignKey(e => e.IdCursoModulo);

            modelBuilder.Entity<Cursos>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Cursos>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Cursos>()
                .HasMany(e => e.Avisos)
                .WithOptional(e => e.Cursos)
                .HasForeignKey(e => e.IdCurso);

            modelBuilder.Entity<Cursos>()
                .HasMany(e => e.CursoModulo)
                .WithOptional(e => e.Cursos)
                .HasForeignKey(e => e.IdCurso);

            modelBuilder.Entity<Cursos>()
                .HasMany(e => e.Turmas)
                .WithOptional(e => e.Cursos)
                .HasForeignKey(e => e.IdCurso);

            modelBuilder.Entity<Docentes>()
                .HasMany(e => e.Turmas)
                .WithOptional(e => e.Docentes)
                .HasForeignKey(e => e.IdDocente);

            modelBuilder.Entity<Escolaridades>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Escolaridades>()
                .HasMany(e => e.Alunos)
                .WithOptional(e => e.Escolaridades)
                .HasForeignKey(e => e.IdEscolaridade);

            modelBuilder.Entity<Modulos>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Modulos>()
                .HasMany(e => e.CursoModulo)
                .WithOptional(e => e.Modulos)
                .HasForeignKey(e => e.IdModulo);

            modelBuilder.Entity<Modulos>()
                .HasMany(e => e.Modulos1)
                .WithOptional(e => e.Modulos2)
                .HasForeignKey(e => e.IdPai);

            modelBuilder.Entity<Pessoas>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoas>()
                .Property(e => e.CPF)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoas>()
                .Property(e => e.Telefone)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoas>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoas>()
                .Property(e => e.Sexo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Pessoas>()
                .HasOptional(e => e.Alunos)
                .WithRequired(e => e.Pessoas);

            modelBuilder.Entity<Pessoas>()
                .HasOptional(e => e.Docentes)
                .WithRequired(e => e.Pessoas);

            modelBuilder.Entity<Pessoas>()
                .HasOptional(e => e.Usuarios)
                .WithRequired(e => e.Pessoas);

            modelBuilder.Entity<TiposAtividade>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<TiposAtividade>()
                .HasMany(e => e.Modulos)
                .WithOptional(e => e.TiposAtividade)
                .HasForeignKey(e => e.IdTipo);

            modelBuilder.Entity<TurmaAluno>()
                .Property(e => e.Status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TurmaAluno>()
                .HasMany(e => e.AlunoModulo)
                .WithOptional(e => e.TurmaAluno)
                .HasForeignKey(e => e.IdTurmaAluno);

            modelBuilder.Entity<Turmas>()
                .Property(e => e.CodTurma)
                .IsUnicode(false);

            modelBuilder.Entity<Turmas>()
                .HasMany(e => e.Avisos)
                .WithOptional(e => e.Turmas)
                .HasForeignKey(e => e.IdTurma);

            modelBuilder.Entity<Turmas>()
                .HasMany(e => e.TurmaAluno)
                .WithOptional(e => e.Turmas)
                .HasForeignKey(e => e.IdTurma);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.Usuario)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.Senha)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.PalavraChave)
                .IsUnicode(false);
        }
    }
}
