using ClassScheduler.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClassScheduler.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Aula> Aulas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<DisponibilidadeDia> DisponibilidadesDias { get; set; }
        public DbSet<DisponibilidadeDisciplina> DisponibilidadesDisciplinas { get; set; }
        public DbSet<DisponibilidadeDisciplinaDia> DisponibilidadesDisciplinasDias { get; set; }
        public DbSet<DisponibilidadeProfessor> DisponibilidadesProfessores { get; set; }
        public DbSet<DisponibilidadeProfessorDia> DisponibilidadesProfessoresDias { get; set; }
        public DbSet<DisponibilidadeSala> DisponibilidadesSalas { get; set; }
        public DbSet<DisponibilidadeSalaDia> DisponibilidadesSalasDias { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Sala> Salas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DisponibilidadeDisciplinaDia>()
            .HasKey(dd => new { dd.DisponibilidadeDisciplinaId, dd.DisponibilidadeDiaId });

            modelBuilder.Entity<DisponibilidadeProfessorDia>()
                .HasKey(pd => new { pd.DisponibilidadeProfessorId, pd.DisponibilidadeDiaId });

            modelBuilder.Entity<DisponibilidadeSalaDia>()
                .HasKey(sd => new { sd.DisponibilidadeSalaId, sd.DisponibilidadeDiaId });
            base.OnModelCreating(modelBuilder);
        }
    }
}