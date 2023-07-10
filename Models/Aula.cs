using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassScheduler.Models
{
    public class Aula : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DataHoraInicio { get; set; }

        [Required]
        public DateTime DataHoraFim { get; set; }

        [ForeignKey("ProfessorId")]
        public virtual Professor Professor { get; set; }
        public int ProfessorId { get; set; }

        [ForeignKey("DisciplinaId")]
        public virtual Disciplina Disciplina { get; set; }
        public int DisciplinaId { get; set; }

        [ForeignKey("SalaId")]
        public virtual Sala Sala { get; set; }
        public int SalaId { get; set; }
    }
}