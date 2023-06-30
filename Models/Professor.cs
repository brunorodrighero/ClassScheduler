using System.ComponentModel.DataAnnotations;

namespace ClassScheduler.Models
{
    public class Professor
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Sobrenome é obrigatório.")]
        [StringLength(100)]
        public string Sobrenome { get; set; }

        [StringLength(100)]
        public string Titulacao { get; set; }

        [Required(ErrorMessage = "O campo E-mail é obrigatório.")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "O formato do E-mail não é válido.")]
        [EmailAddress(ErrorMessage = "O E-mail não é válido.")]
        public string Email { get; set; }

        [RegularExpression(@"^\(\d{2}\)\d{4}-\d{4}$", ErrorMessage = "O campo Telefone não está no formato correto.")]
        [Phone(ErrorMessage = "O telefone não é válido.")]
        public string Telefone { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public List<Disponibilidade> Disponibilidades { get; set; }

        public List<Aula> Aulas { get; set; }
    }
}
