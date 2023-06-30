using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassScheduler.Models
{
    public class Disciplina
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        public int CargaHoraria { get; set; }

        [Required]
        public int Creditos { get; set; }

        [StringLength(500)]
        public string Descricao { get; set; }

        [ForeignKey("CursoId")]
        public Curso Curso { get; set; }
        public int CursoId { get; set; }

        public List<Aula> Aulas { get; set; }

        public List<Disponibilidade> Disponibilidades { get; set; }
    }
}