using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassScheduler.Models
{
    public class DisponibilidadeDia
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DayOfWeek DiaDaSemana { get; set; }

        [Required]
        public TimeSpan HoraInicio { get; set; }

        [Required]
        public TimeSpan HoraFim { get; set; }

        [ForeignKey("DisponibilidadeId")]
        public Disponibilidade Disponibilidade { get; set; }
        public int DisponibilidadeId { get; set; }
    }
}