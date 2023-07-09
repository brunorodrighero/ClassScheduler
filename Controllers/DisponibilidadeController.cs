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

        public IActionResult CriarDispProfessor(int id)
        {
            var professor = _context.Professores.Find(id);
            if (professor == null)
            {
                return NotFound();
            }

            var dispProfessor = _context.DisponibilidadesProfessores
                .Include(dp => dp.DisponibilidadeProfessorDias)
                .ThenInclude(dpd => dpd.DisponibilidadeDia)
                .ThenInclude(dd => dd.Horarios)
                .FirstOrDefault(dp => dp.ProfessorId == id);

            if (dispProfessor == null)
            {
                dispProfessor = new DisponibilidadeProfessor
                {
                    Professor = professor
                };
            }

            return View(dispProfessor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CriarDispProfessor(int id, DisponibilidadeProfessor dispProfessor)
        {
            if (ModelState.IsValid)
            {
                var existingDispProfessor = _context.DisponibilidadesProfessores
                    .Include(dp => dp.DisponibilidadeProfessorDias)
                    .ThenInclude(dpd => dpd.DisponibilidadeDia)
                    .ThenInclude(dd => dd.Horarios)
                    .FirstOrDefault(dp => dp.ProfessorId == id);

                if (existingDispProfessor != null)
                {
                    // Atualizar os horários existentes aqui
                    // Remova os antigos, adicione novos
                }
                else
                {
                    // Criar nova disponibilidade
                    _context.Add(dispProfessor);
                }

                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(dispProfessor);
        }
    }


}
