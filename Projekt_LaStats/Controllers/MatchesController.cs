using Microsoft.AspNetCore.Mvc;

namespace Projekt_LaStats.Controllers
{
    public class MatchesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
