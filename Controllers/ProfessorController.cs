using ClassScheduler.Data;
using ClassScheduler.Models;
using ClassScheduler.Repo;
using Microsoft.AspNetCore.Mvc;

namespace ClassScheduler.Controllers
{

    public class ProfessorController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IProfessorRepo _professorRepo;
        public ProfessorController(ApplicationDbContext context, IProfessorRepo professorRepo)
        {
            _context = context;
            _professorRepo = professorRepo;
        }
        public async Task<IActionResult> Index()
        {
            List<Professor> professores = await _professorRepo.BuscarTodosAsync();
            return View(professores);
        }

        //[Authorize]
        public IActionResult Criar() => View(new Professor());

        public async Task<IActionResult> Editar(int id)
        {
            Professor professor = await _professorRepo.ListarPorIdAsync(id);
            return professor == null ? NotFound() : View(professor);
        }

        public async Task<IActionResult> Apagar(int id)
        {
            Professor professor = await _professorRepo.ListarPorIdAsync(id);
            return professor == null ? NotFound() : View(professor);
        }

        public async Task<IActionResult> ApagarProfessor(int id)
        {
            try
            {
                bool apagado = await _professorRepo.ApagarAsync(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Professor deletado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos deletar o Professor. Tente novamente.";
                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos deletar o Professor. Tente novamente. Detalhe do erro: {erro.Message}.";
                return RedirectToAction("Index");
            }
        }

        //[Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(Professor professor)
        {
            try
            {
                if (!ModelState["Nome"].Errors.Any() && !ModelState["Sobrenome"].Errors.Any() && !ModelState["Email"].Errors.Any() && !ModelState["Telefone"].Errors.Any() && !ModelState["Titulacao"].Errors.Any())
                {
                    professor.DataCadastro = DateTime.Now;
                    await _professorRepo.AdicionarAsync(professor);
                    TempData["MensagemSucesso"] = "Professor cadastrado com sucesso";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["MensagemErro"] = $"Ops, dados digitados incorretamente.";
                    return View(professor);
                }
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar o(a) professor(a). Tente novamente. Detalhe do erro: {erro.Message}.";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarProfessor(Professor professor)
        {
            try
            {
                if (!ModelState["Nome"].Errors.Any() && !ModelState["Sobrenome"].Errors.Any() && !ModelState["Email"].Errors.Any() && !ModelState["Telefone"].Errors.Any() && !ModelState["Titulacao"].Errors.Any())
                {
                    await _professorRepo.EditarAsync(professor);
                    TempData["MensagemSucesso"] = "Professor(a) alterado(a) com sucesso";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MensagemErro"] = $"Ops, dados digitados incorretamente.";
                    return View(professor);
                }
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar o(a) professor(a). Tente novamente. Detalhe do erro: {erro.Message}.";
                return RedirectToAction("Index");
            }
        }
    }
}
