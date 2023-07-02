using ClassScheduler.Data;
using ClassScheduler.Models;
using ClassScheduler.Repo;
using Microsoft.AspNetCore.Mvc;

namespace ClassScheduler.Controllers
{
    public class CursoController : Controller
    {
        public readonly ApplicationDbContext _context;
        private readonly ICursoRepo _cursoRepo;
        public CursoController(ApplicationDbContext context, ICursoRepo cursoRepo)
        {
            _context = context;
            _cursoRepo = cursoRepo;

        }
        public async Task<IActionResult> Index()
        {
            List<Curso> cursos = await _cursoRepo.BuscarTodosAsync();
            return View(cursos);
        }

        public IActionResult Criar() => View(new Curso());


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(Curso curso)
        {
            try
            {
                if (!ModelState["Nome"].Errors.Any() && !ModelState["Duracao"].Errors.Any() && !ModelState["Descricao"].Errors.Any())
                {
                    curso.DataCadastro = DateTime.Now;
                    await _cursoRepo.AdicionarAsync(curso);
                    TempData["MensagemSucesso"] = "Curso cadastrado com sucesso";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["MensagemErro"] = $"Ops, dados digitados incorretamente.";
                    return View(curso);
                }
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar o curso. Tente novamente. Detalhe do erro: {erro.Message}.";
                return RedirectToAction("Index");
            }
        }
    }
}
