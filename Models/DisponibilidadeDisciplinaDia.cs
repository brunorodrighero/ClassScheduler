using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassScheduler.Models
{
    public class DisponibilidadeDisciplinaDia
    {
        [Key]
        public int Id { get; set; }

        public int DisponibilidadeDisciplinaId { get; set; }

        [ForeignKey(nameof(DisponibilidadeDisciplinaId))]
        public virtual DisponibilidadeDisciplina DisponibilidadeDisciplina { get; set; }

        public int DiaDisponibilidadeId { get; set; }

        [ForeignKey(nameof(DiaDisponibilidadeId))]
        public virtual DisponibilidadeDia DisponibilidadeDia { get; set; }

        public int HorarioId { get; set; }

        [ForeignKey(nameof(HorarioId))]
        public virtual Horario Horario { get; set; }
    }
}