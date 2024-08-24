using CleanArch.Domain.Entities;
using CleanArch.Infrastructure.Maps;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure
{
    public class Contexto : DbContext
    {
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Matricula> Matricula { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options) 
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=SABRL6S7NS53; Applicationbase=CleanArch; Trusted_Connection=True; TrustServerCertificate=True"); 
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new ProfessorMap());
            modelBuilder.ApplyConfiguration(new CursoMap());
            modelBuilder.ApplyConfiguration(new MatriculaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
