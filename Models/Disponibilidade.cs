﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassScheduler.Models
{
    public class Disponibilidade
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ProfessorId")]
        public Professor? Professor { get; set; }
        public int? ProfessorId { get; set; }

        [ForeignKey("SalaId")]
        public Sala? Sala { get; set; }
        public int? SalaId { get; set; }

        [ForeignKey("DisciplinaId")]
        public Disciplina? Disciplina { get; set; }
        public int? DisciplinaId { get; set; }

        public ICollection<DisponibilidadeDia> DisponibilidadeDias { get; set; }

        public DateTime? DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }
    }
}