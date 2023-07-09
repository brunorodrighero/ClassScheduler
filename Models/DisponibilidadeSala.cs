using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassScheduler.Models
{
    public class DisponibilidadeSala
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("SalaId")]
        public virtual Sala Sala { get; set; }
        public int SalaId { get; set; }

        public virtual ICollection<DisponibilidadeSalaDia> DisponibilidadeSalaDias { get; set; }

        public DateTime? DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }
    }
}
