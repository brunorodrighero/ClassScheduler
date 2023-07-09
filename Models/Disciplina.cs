using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassScheduler.Models
{
    public class Disciplina
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public int CargaHoraria { get; set; }

        public int? Creditos { get; set; }
        public int QuantAulasPorSemana { get; set; }

        public string? Descricao { get; set; }

        [ForeignKey("CursoId")]
        public virtual Curso? Curso { get; set; }
        public int? CursoId { get; set; }

        public virtual List<Aula>? Aulas { get; set; }

        public virtual List<DisponibilidadeProfessor>? Disponibilidades { get; set; }

        public DateTime? DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }
    }
}