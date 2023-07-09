﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassScheduler.Models
{
    public class Horario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public TimeSpan HoraInicio { get; set; }

        [Required]
        public TimeSpan HoraFim { get; set; }

        [ForeignKey("DisponibilidadeDiaId")]
        public virtual DisponibilidadeDia DisponibilidadeDia { get; set; }
        public int DisponibilidadeDiaId { get; set; }
    }
}
