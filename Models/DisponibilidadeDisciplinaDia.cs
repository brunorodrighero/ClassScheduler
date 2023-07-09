using System.ComponentModel.DataAnnotations.Schema;

namespace ClassScheduler.Models
{
    public class DisponibilidadeDisciplinaDia
    {
        public int DisponibilidadeDisciplinaId { get; set; }
        [ForeignKey("DisponibilidadeDisciplinaId")]
        public virtual DisponibilidadeDisciplina DisponibilidadeDisciplina { get; set; }

        public int DisponibilidadeDiaId { get; set; }
        [ForeignKey("DisponibilidadeDiaId")]
        public virtual DisponibilidadeDia DisponibilidadeDia { get; set; }
    }
}