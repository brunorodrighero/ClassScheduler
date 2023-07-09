using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassScheduler.Models
{
    public class DisponibilidadeProfessorDia
    {
        [Key]
        public int Id { get; set; }
        public int DisponibilidadeProfessorId { get; set; }
        [ForeignKey("DisponibilidadeProfessorId")]
        public virtual DisponibilidadeProfessor DisponibilidadeProfessor { get; set; }

        public int DisponibilidadeDiaId { get; set; }
        [ForeignKey("DisponibilidadeDiaId")]
        public virtual DisponibilidadeDia DisponibilidadeDia { get; set; }

        [ForeignKey("Horario")]
        public int HorarioId { get; set; }
        public virtual Horario Horario { get; set; }
    }
}