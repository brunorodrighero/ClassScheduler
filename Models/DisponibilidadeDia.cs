using System.ComponentModel.DataAnnotations;

namespace ClassScheduler.Models
{
    public class DisponibilidadeDia : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DayOfWeek DiaDaSemana { get; set; }

        public virtual ICollection<Professor>? Professores { get; set; }
        public virtual ICollection<Sala>? Salas { get; set; }
        public virtual ICollection<Disciplina>? Disciplinas { get; set; }
        public virtual ICollection<DisponibilidadeHorario>? HorariosDisponiveis { get; set; }
    }
}