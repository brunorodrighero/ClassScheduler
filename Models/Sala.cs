using System.ComponentModel.DataAnnotations;

namespace ClassScheduler.Models
{
    public class Sala
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Numero { get; set; }

        [Required]
        [Range(1, 60)]
        public int Capacidade { get; set; }

        [StringLength(500)]
        public string Descricao { get; set; }

        public List<Aula> Aulas { get; set; }

        public List<Disponibilidade> Disponibilidades { get; set; }
    }

}