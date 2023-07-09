using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassScheduler.Models
{
    public class DisponibilidadeSalaDia
    {
        [Key, Column(Order = 0)]
        public int DisponibilidadeSalaId { get; set; }
        [ForeignKey("DisponibilidadeSalaId")]
        public virtual DisponibilidadeSala DisponibilidadeSala { get; set; }

        [Key, Column(Order = 1)]
        public int DisponibilidadeDiaId { get; set; }
        [ForeignKey("DisponibilidadeDiaId")]
        public virtual DisponibilidadeDia DisponibilidadeDia { get; set; }
    }
}