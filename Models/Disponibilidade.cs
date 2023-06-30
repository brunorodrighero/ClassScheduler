﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassScheduler.Models
{
    public class Disponibilidade
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DataHoraInicio { get; set; }

        [Required]
        public DateTime DataHoraFim { get; set; }

        [ForeignKey("ProfessorId")]
        public Professor Professor { get; set; }
        public int ProfessorId { get; set; }

        [ForeignKey("SalaId")]
        public Sala Sala { get; set; }
        public int SalaId { get; set; }
    }
}