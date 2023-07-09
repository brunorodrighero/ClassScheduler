using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassScheduler.Models
{
    public class DisponibilidadeDisciplinaDia
    {
        [Key, Column(Order = 0)]
        public int DisponibilidadeDisciplinaId { get; set; }
        [ForeignKey("DisponibilidadeDisciplinaId")]
        public virtual DisponibilidadeDisciplina DisponibilidadeDisciplina { get; set; }

        [Key, Column(Order = 1)]
        public int DisponibilidadeDiaId { get; set; }
        [ForeignKey("DisponibilidadeDiaId")]
        public virtual DisponibilidadeDia DisponibilidadeDia { get; set; }
    }
}