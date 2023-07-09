using System.ComponentModel.DataAnnotations.Schema;

namespace ClassScheduler.Models
{
    public class DisponibilidadeProfessorDia
    {
        public int DisponibilidadeProfessorId { get; set; }
        [ForeignKey("DisponibilidadeProfessorId")]
        public virtual DisponibilidadeProfessor DisponibilidadeProfessor { get; set; }

        public int DisponibilidadeDiaId { get; set; }
        [ForeignKey("DisponibilidadeDiaId")]
        public virtual DisponibilidadeDia DisponibilidadeDia { get; set; }
    }
}