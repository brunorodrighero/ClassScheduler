using ClassScheduler.Data;
using ClassScheduler.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClassScheduler.Controllers
{
    public class DisponibilidadeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private List<DisponibilidadeDia> DisponibilidadeDias;

        public DisponibilidadeController(ApplicationDbContext context)
        {
            _context = context;
            DisponibilidadeDias = new List<DisponibilidadeDia>();
        }

        public IActionResult DispProfessor()
        {
            List<Professor> professores = _context.Professores.ToList();
            ViewBag.Professor = new SelectList(professores, "Id", "NomeCompleto");
            return View(new DisponibilidadeProfessor());
        }

        public IActionResult DispDisciplina()
        {
            return View();
        }

        public IActionResult DispAula()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CriarDispProfessor(DisponibilidadeProfessor disponibilidadeProfessor, string disponibilidadeDias)
        {
            // Converte disponibilidadeDias de string para uma lista de objetos DisponibilidadeDia
            if (disponibilidadeProfessor != null && disponibilidadeDias != null)
            {
                disponibilidadeProfessor.DisponibilidadeDias = disponibilidadeDias.Split(',').Select(s => new DisponibilidadeDia
                {
                    DiaDaSemana = (DayOfWeek)int.Parse(s.Split('-')[0]),
                    HoraInicio = TimeSpan.Parse(s.Split('-')[1]),
                    // Calcula HoraFim com base em HoraInicio
                    HoraFim = TimeSpan.Parse(s.Split('-')[1]).Add(TimeSpan.FromMinutes(50))  // Atualize isso de acordo com a duração da aula
                }).ToList();
            }
            else
            {
                // Lidar com a situação em que disponibilidade ou disponibilidadeDias é null
            }


            if (/*ModelState.IsValid*/true)
            {
                // Cria a nova disponibilidade
                _context.Disponibilidades.Add(disponibilidadeProfessor);

                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {
                return View(disponibilidadeProfessor);
            }
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarDispProfessor(DisponibilidadeProfessor disponibilidade)
        {
            if (/*ModelState.IsValid*/true)
            {
                // Remove todas as disponibilidades anteriores deste professor
                var disponibilidadesAnteriores = _context.DisponibilidadesDias.Where(dd => dd.Disponibilidade.ProfessorId == disponibilidade.ProfessorId);
                _context.DisponibilidadesDias.RemoveRange(disponibilidadesAnteriores);

                // Salva a nova disponibilidade
                foreach (var dia in disponibilidade.DisponibilidadeDias)
                {
                    _context.DisponibilidadesDias.Add(new DisponibilidadeDia { Disponibilidade = disponibilidade, DiaDaSemana = dia.DiaDaSemana, HoraInicio = dia.HoraInicio, HoraFim = dia.HoraFim });
                }

                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {
                return View(disponibilidade);
            }
        }

        public DayOfWeek ConvertStringToDayOfWeek(string dayOfWeekString)
        {
            return Enum.Parse<DayOfWeek>(dayOfWeekString, ignoreCase: true);
        }

        public TimeSpan ConvertStringToTimeSpan(string timeString)
        {
            return TimeSpan.Parse(timeString);
        }
    }
}
