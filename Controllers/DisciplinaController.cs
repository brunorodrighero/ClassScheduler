using Microsoft.AspNetCore.Mvc;

namespace ClassScheduler.Controllers
{
    public class DisciplinaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
