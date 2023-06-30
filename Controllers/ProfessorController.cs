using ClassScheduler.Data;
using ClassScheduler.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClassScheduler.Controllers
{

    public class ProfessorController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProfessorController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index() => View();

        [Authorize]
        public IActionResult Criar() => View(new Professor());

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Criar([Bind("Id,Nome,Sobrenome,Titulacao,Email,Telefone,DataCadastro")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(professor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(professor);
        }

        public async Task<IActionResult> Editar(int id)
        {
            //alterar
            string professor = "";
            return professor == null ? NotFound() : View(professor);
        }

        public async Task<IActionResult> Apagar(int id)
        {
            //alterar
            string professor = "";
            return professor == null ? NotFound() : View(professor);
        }
    }
}
