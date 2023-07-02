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

        //[Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(Professor professor)
        {
            try
            {
                if (!ModelState["Nome"].Errors.Any() && !ModelState["Sobrenome"].Errors.Any() && !ModelState["Email"].Errors.Any() && !ModelState["Telefone"].Errors.Any())
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

                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar o professor. Tente novamente. Detalhe do erro: {erro.Message}.";
                return RedirectToAction("Index");
            }
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
