using System.ComponentModel.DataAnnotations;

namespace ClassScheduler.Models
{
    public class Sala : BaseEntity
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
        public string? Descricao { get; set; }

        public virtual List<Aula>? Aulas { get; set; }

        public virtual ICollection<DisponibilidadeDia>? DiasDisponiveis { get; set; }
    }

}