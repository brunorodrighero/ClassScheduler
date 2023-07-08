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
            return View(new Disponibilidade());
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
        public async Task<IActionResult> EditarDispProfessor(Disponibilidade disponibilidade)
        {
            if (ModelState.IsValid)
            {
                // Busca a disponibilidade do professor com base no ProfessorId
                var professorDisponibilidade = await _context.Disponibilidades
                    .Include(d => d.Professor)
                    .Where(d => d.ProfessorId == disponibilidade.ProfessorId)
                    .ToListAsync();

                // Redireciona para a view EditarDispProfessor com os dados da disponibilidade
                return View("EditarDispProfessor", professorDisponibilidade);
            }

            // Se o ModelState for inválido, retorna para a mesma view com os erros
            return View(disponibilidade);
        }

    }
}
