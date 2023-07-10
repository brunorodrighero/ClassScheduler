using System.ComponentModel.DataAnnotations;

namespace ClassScheduler.Models
{
    public class DisponibilidadeHorario : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public TimeSpan HoraInicio { get; set; }

        [Required]
        public TimeSpan HoraFim { get; set; }

        public virtual ICollection<DisponibilidadeDia>? DiasDisponiveis { get; set; }
    }
}

