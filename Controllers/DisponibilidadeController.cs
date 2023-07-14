using ClassScheduler.Data;
using ClassScheduler.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ClassScheduler.Controllers
{
    public class DisponibilidadeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DisponibilidadeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult DispProfessor()
        {
            List<Professor> professores = _context.Professores.ToList();
            ViewBag.Professor = new SelectList(professores, "Id", "NomeCompleto");
            return View(new Professor());
        }

        public IActionResult DispDisciplina()
        {
            List<Disciplina> disciplinas = _context.Disciplinas.ToList();
            ViewBag.Disciplina = new SelectList(disciplinas, "Id", "Nome");
            return View(new Disciplina());
        }

        public IActionResult DispAula()
        {
            return View();
        }

        public IActionResult SelecionarProfessor(int id, string action)
        {
            var professor = _context.Professores.Find(id);
            if (professor == null)
            {
                return NotFound();
            }

            switch (action)
            {
                case "CriarDispProfessor":
                    return RedirectToAction("CriarDispProfessor", new { id });
                case "MostrarDispProfessor":
                    return RedirectToAction("MostrarDispProfessor", new { id });
                default:
                    return View();
            }
        }

        public IActionResult MostrarDispProfessor(int id)
        {
            var professor = _context.Professores
                                    .Include(p => p.DiasDisponiveis) // Carrega os dias disponíveis do professor.
                                    .ThenInclude(d => d.HorariosDisponiveis) // Carrega os horários disponíveis de cada dia.
                                    .FirstOrDefault(p => p.Id == id);

            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        public IActionResult CriarDispProfessor(int id)
        {
            var professor = _context.Professores.Find(id);
            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CriarDispProfessor(int id, string DisponibilidadeDiasInput)
        {
            var professor = _context.Professores.Find(id);
            if (professor == null)
            {
                return NotFound();
            }

            var disponibilidadeDiasInput = DisponibilidadeDiasInput ?? "";
            var disponibilidades = disponibilidadeDiasInput.Split(",", StringSplitOptions.RemoveEmptyEntries);

            foreach (var disponibilidade in disponibilidades)
            {
                var parts = disponibilidade.Split("-").Select(p => p.Trim()).ToList();
                var diaDaSemana = (DayOfWeek)int.Parse(parts[0]);
                var horaInicio = TimeSpan.Parse(parts[1]);
                var horaFim = TimeSpan.Parse(parts[2]);

                // Busca por dia disponível existente ou cria um novo.
                var diaDisponivel = professor.DiasDisponiveis?.FirstOrDefault(d => d.DiaDaSemana == diaDaSemana);
                if (diaDisponivel == null)
                {
                    diaDisponivel = new DisponibilidadeDia { DiaDaSemana = diaDaSemana };
                    professor.DiasDisponiveis ??= new List<DisponibilidadeDia>();
                    professor.DiasDisponiveis.Add(diaDisponivel);
                }

                // Busca por horário disponível existente ou cria um novo.
                var horarioDisponivel = diaDisponivel.HorariosDisponiveis?.FirstOrDefault(h => h.HoraInicio == horaInicio && h.HoraFim == horaFim);
                if (horarioDisponivel == null)
                {
                    horarioDisponivel = new DisponibilidadeHorario { HoraInicio = horaInicio, HoraFim = horaFim };
                    diaDisponivel.HorariosDisponiveis ??= new List<DisponibilidadeHorario>();
                    diaDisponivel.HorariosDisponiveis.Add(horarioDisponivel);
                }
            }

            _context.Professores.Update(professor);
            _context.SaveChanges();

            return RedirectToAction(nameof(DispProfessor));
        }

        public IActionResult SelecionarDisciplina(int id, string action)
        {
            var disciplina = _context.Disciplinas.Find(id);
            if (disciplina == null)
            {
                return NotFound();
            }
            switch (action)
            {
                case "CriarDispDisciplina":
                    return RedirectToAction("CriarDispDisciplina", new { id });
                case "MostrarDispDisciplina":
                    return RedirectToAction("MostrarDispDisciplina", new { id });
                default:
                    return View();
            }
        }

        public IActionResult CriarDispDisciplina(int id)
        {
            var disciplina = _context.Disciplinas.Find(id);
            if (disciplina == null)
            {
                return NotFound();
            }

            return View(disciplina);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CriarDispDisciplina(int id, string DisponibilidadeDiasInput)
        {
            var disciplina = _context.Disciplinas.Find(id);
            if (disciplina == null)
            {
                return NotFound();
            }
            var disponibilidadeDiasInput = DisponibilidadeDiasInput ?? "";
            var disponibilidades = disponibilidadeDiasInput.Split(",", StringSplitOptions.RemoveEmptyEntries);

            foreach (var disponibilidade in disponibilidades)
            {
                var parts = disponibilidade.Split("-").Select(p => p.Trim()).ToList();
                var diaDaSemana = (DayOfWeek)int.Parse(parts[0]);
                var horaInicio = TimeSpan.Parse(parts[1]);
                var horaFim = TimeSpan.Parse(parts[2]);

                // Busca por dia disponível existente ou cria um novo.
                var diaDisponivel = disciplina.DiasDisponiveis?.FirstOrDefault(d => d.DiaDaSemana == diaDaSemana);
                if (diaDisponivel == null)
                {
                    diaDisponivel = new DisponibilidadeDia { DiaDaSemana = diaDaSemana };
                    disciplina.DiasDisponiveis ??= new List<DisponibilidadeDia>();
                    disciplina.DiasDisponiveis.Add(diaDisponivel);
                }
                //se diaDisponivel não for nulo, deletar a entrada do dia disponível que está no banco de dados
                else
                {
                    _context.DisponibilidadesDias.Remove(diaDisponivel);
                }

                //Busca por horário disponível existente ou cria um novo.
                var horarioDisponivel = diaDisponivel.HorariosDisponiveis?.FirstOrDefault(h => h.HoraInicio == horaInicio && h.HoraFim == horaFim);
                if (horarioDisponivel == null)
                {
                    horarioDisponivel = new DisponibilidadeHorario { HoraInicio = horaInicio, HoraFim = horaFim };
                    diaDisponivel.HorariosDisponiveis ??= new List<DisponibilidadeHorario>();
                    diaDisponivel.HorariosDisponiveis.Add(horarioDisponivel);
                }

                //se horarioDisponivel não for nulo, deletar a entrada do horário disponível que está no banco de dados
                else
                {
                    _context.DisponibilidadesHorarios.Remove(horarioDisponivel);
                }

                _context.Disciplinas.Update(disciplina);
                _context.SaveChanges();

                return RedirectToAction(nameof(DispDisciplina));
            }
        }
    }
}
