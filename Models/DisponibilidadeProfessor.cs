using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassScheduler.Models
{
    public class DisponibilidadeProfessor
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ProfessorId")]
        public virtual Professor Professor { get; set; }
        public int ProfessorId { get; set; }

        public virtual ICollection<DisponibilidadeProfessorDia> DisponibilidadeProfessorDias { get; set; }

        public DateTime? DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }
    }
}