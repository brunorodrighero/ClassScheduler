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
            //modelBuilder.Entity<DisponibilidadeDisciplinaDia>()
            //.HasKey(dd => new { dd.DisponibilidadeDisciplinaId, dd.DisponibilidadeDiaId, dd.HorarioId });

            //modelBuilder.Entity<DisponibilidadeProfessorDia>()
            //    .HasKey(pd => new { pd.DisponibilidadeProfessorId, pd.DisponibilidadeDiaId, pd.HorarioId });

            //modelBuilder.Entity<DisponibilidadeSalaDia>()
            //    .HasKey(sd => new { sd.DisponibilidadeSalaId, sd.DisponibilidadeDiaId, sd.HorarioId });

            modelBuilder.Entity<DisponibilidadeDisciplinaDia>()
    .HasKey(dd => dd.Id);

            modelBuilder.Entity<DisponibilidadeProfessorDia>()
                .HasKey(pd => pd.Id);

            modelBuilder.Entity<DisponibilidadeSalaDia>()
                .HasKey(sd => sd.Id);

            modelBuilder.Entity<DisponibilidadeDisciplinaDia>()
                .HasOne(dd => dd.Horario)
                .WithMany()
                .HasForeignKey(dd => dd.HorarioId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DisponibilidadeDisciplinaDia>()
                .HasOne(dd => dd.DisponibilidadeDia)
                .WithMany()
                .HasForeignKey(dd => dd.DiaDisponibilidadeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DisponibilidadeDisciplinaDia>()
                .HasOne(dd => dd.DisponibilidadeDisciplina)
                .WithMany()
                .HasForeignKey(dd => dd.DisponibilidadeDisciplinaId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DisponibilidadeProfessorDia>()
                .HasOne(pd => pd.Horario)
                .WithMany()
                .HasForeignKey(pd => pd.HorarioId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DisponibilidadeProfessorDia>()
                .HasOne(pd => pd.DisponibilidadeDia)
                .WithMany()
                .HasForeignKey(pd => pd.DisponibilidadeDiaId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DisponibilidadeProfessorDia>()
                .HasOne(pd => pd.DisponibilidadeProfessor)
                .WithMany()
                .HasForeignKey(pd => pd.DisponibilidadeProfessorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DisponibilidadeSalaDia>()
                .HasOne(sd => sd.Horario)
                .WithMany()
                .HasForeignKey(sd => sd.HorarioId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DisponibilidadeSalaDia>()
                .HasOne(sd => sd.DisponibilidadeDia)
                .WithMany()
                .HasForeignKey(sd => sd.DisponibilidadeDiaId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DisponibilidadeSalaDia>()
                .HasOne(sd => sd.DisponibilidadeSala)
                .WithMany()
                .HasForeignKey(sd => sd.DisponibilidadeSalaId)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }
    }
}