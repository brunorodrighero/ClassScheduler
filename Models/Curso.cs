using System.ComponentModel.DataAnnotations;

namespace ClassScheduler.Models
{
    public class Curso
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        public int Duracao { get; set; } // em semestres ou anos

        public string Descricao { get; set; }

        public List<Disciplina> Disciplinas { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }
    }
}