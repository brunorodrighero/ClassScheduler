using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassScheduler.Models
{
    public class DisponibilidadeSalaDia
    {
        [Key]
        public int Id { get; set; }
        public int DisponibilidadeSalaId { get; set; }
        [ForeignKey("DisponibilidadeSalaId")]
        public virtual DisponibilidadeSala DisponibilidadeSala { get; set; }

        public int DisponibilidadeDiaId { get; set; }
        [ForeignKey("DisponibilidadeDiaId")]
        public virtual DisponibilidadeDia DisponibilidadeDia { get; set; }

        [ForeignKey("Horario")]
        public int HorarioId { get; set; }
        public virtual Horario Horario { get; set; }
    }
}