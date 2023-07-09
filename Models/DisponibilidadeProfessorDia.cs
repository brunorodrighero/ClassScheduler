using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassScheduler.Models
{
    public class DisponibilidadeProfessorDia
    {
        [Key, Column(Order = 0)]
        public int DisponibilidadeProfessorId { get; set; }
        [ForeignKey("DisponibilidadeProfessorId")]
        public virtual DisponibilidadeProfessor DisponibilidadeProfessor { get; set; }

        [Key, Column(Order = 1)]
        public int DisponibilidadeDiaId { get; set; }
        [ForeignKey("DisponibilidadeDiaId")]
        public virtual DisponibilidadeDia DisponibilidadeDia { get; set; }
    }
}