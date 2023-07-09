using System.ComponentModel.DataAnnotations.Schema;

namespace ClassScheduler.Models
{
    public class DisponibilidadeSalaDia
    {
        public int DisponibilidadeSalaId { get; set; }
        [ForeignKey("DisponibilidadeSalaId")]
        public virtual DisponibilidadeSala DisponibilidadeSala { get; set; }

        public int DisponibilidadeDiaId { get; set; }
        [ForeignKey("DisponibilidadeDiaId")]
        public virtual DisponibilidadeDia DisponibilidadeDia { get; set; }
    }
}