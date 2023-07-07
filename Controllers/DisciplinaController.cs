using ClassScheduler.Data;
using ClassScheduler.Models;
using ClassScheduler.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClassScheduler.Controllers
{
    public class DisciplinaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDisciplinaRepo _disciplinaRepo;
        public DisciplinaController(ApplicationDbContext context, IDisciplinaRepo disciplinaRepo)
        {
            _context = context;
            _disciplinaRepo = disciplinaRepo;
        }
        public async Task<IActionResult> Index()
        {
            List<Disciplina> disciplinas = await _disciplinaRepo.BuscarTodosComCursoAsync();

            return View(disciplinas);
        }
        public IActionResult Criar()
        {
            var cursos = _context.Cursos.ToList();
            ViewBag.Cursos = new SelectList(cursos, "Id", "Nome");
            return View(new Disciplina());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(Disciplina disciplina)
        {
            try
            {
                if (!ModelState["Nome"].Errors.Any() && !ModelState["CargaHoraria"].Errors.Any() && !ModelState["Creditos"].Errors.Any() && !ModelState["CursoId"].Errors.Any())
                {
                    disciplina.DataCadastro = DateTime.Now;
                    await _disciplinaRepo.AdicionarAsync(disciplina);
                    TempData["MensagemSucesso"] = "Disciplina cadastrada com sucesso";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var cursos = _context.Cursos.ToList();
                    ViewBag.Cursos = new SelectList(cursos, "Id", "Nome");
                    TempData["MensagemErro"] = $"Ops, dados digitados incorretamente.";
                    return View(disciplina);
                }
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar a Disciplina. Tente novamente. Detalhe do erro: {erro.Message}.";
                return RedirectToAction("Index");
            }
        }
    }
}
