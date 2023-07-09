using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassScheduler.Models
{
    public class DisponibilidadeDisciplina
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("DisciplinaId")]
        public virtual Disciplina Disciplina { get; set; }
        public int DisciplinaId { get; set; }

        public virtual ICollection<DisponibilidadeDisciplinaDia> DisponibilidadeDisciplinaDias { get; set; }

        public DateTime? DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }
    }
}
