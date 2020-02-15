using Cadastro.Entidades;
using System.Data.Entity;

namespace Cadastro.Repositório
{
    public class Contexto : DbContext
    {
        public virtual DbSet<Aluno> Alunos { get; set; }
        public virtual DbSet<Materia> Materias { get; set; }
        public virtual DbSet<Nota>  Notas { get; set; }

        public Contexto()
        {
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nota>()
                .HasRequired(x => x.Aluno)
                .WithMany(g => g.Notas)
                .HasForeignKey(s => s.AlunoId);

            modelBuilder.Entity<Nota>()
                .HasRequired(x => x.Materia)
                .WithMany(g => g.Notas)
                .HasForeignKey(s => s.MateriaId);
        }
    }

}

