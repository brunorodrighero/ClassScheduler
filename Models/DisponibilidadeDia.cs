using System.ComponentModel.DataAnnotations;

namespace ClassScheduler.Models
{
    public class DisponibilidadeDia
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DayOfWeek DiaDaSemana { get; set; }

        public virtual ICollection<Horario> Horarios { get; set; }

        public virtual ICollection<DisponibilidadeProfessorDia>? DisponibilidadeProfessorDias { get; set; }

        public virtual ICollection<DisponibilidadeDisciplinaDia>? DisponibilidadeDisciplinaDias { get; set; }

        public virtual ICollection<DisponibilidadeSalaDia>? DisponibilidadeSalaDias { get; set; }

        public DateTime? DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }

    }
}