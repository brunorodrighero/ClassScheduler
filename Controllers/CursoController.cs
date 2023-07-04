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

        public async Task<IActionResult> Editar(int id)
        {
            Curso curso = await _cursoRepo.ListarPorIdAsync(id);
            return curso == null ? NotFound() : View(curso);
        }

        public async Task<IActionResult> Apagar(int id)
        {
            Curso curso = await _cursoRepo.ListarPorIdAsync(id);
            return curso == null ? NotFound() : View(curso);
        }

        public async Task<IActionResult> ApagarCurso(int id)
        {
            try
            {
                bool apagado = await _cursoRepo.ApagarAsync(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Curso deletado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos deletar o Curso. Tente novamente.";
                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos deletar o Curso. Tente novamente. Detalhe do erro: {erro.Message}.";
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(Curso curso)
        {
            try
            {
                if (!ModelState["Nome"].Errors.Any() && !ModelState["Duracao"].Errors.Any())
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarCurso(Curso curso)
        {
            try
            {
                if (!ModelState["Nome"].Errors.Any() && !ModelState["Duracao"].Errors.Any())
                {
                    await _cursoRepo.EditarAsync(curso);
                    TempData["MensagemSucesso"] = "Curso alterado com sucesso";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MensagemErro"] = $"Ops, dados digitados incorretamente.";
                    return View(curso);
                }
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar o Curso. Tente novamente. Detalhe do erro: {erro.Message}.";
                return RedirectToAction("Index");
            }
        }
    }
}
