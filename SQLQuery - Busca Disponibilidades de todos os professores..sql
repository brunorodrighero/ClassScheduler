SELECT p.Nome, p.Sobrenome, d.DiaDaSemana, h.HoraInicio, h.HoraFim
FROM Professores p
INNER JOIN DisponibilidadeDiaProfessor pd ON p.Id = pd.ProfessoresId
INNER JOIN DisponibilidadesDias d ON pd.DiasDisponiveisId = d.Id
INNER JOIN DisponibilidadeDiaDisponibilidadeHorario dh ON d.Id = dh.DiasDisponiveisId
INNER JOIN DisponibilidadesHorarios h ON dh.HorariosDisponiveisId = h.Id