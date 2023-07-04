using Microsoft.AspNetCore.Mvc;
using Projekt_LaStats.Service;

namespace Projekt_LaStats.Controllers
{
    public class MatchesController : Controller
    {
        private readonly ILogger<MatchesController> logger;
        private readonly IMatchesService matchesService;

        public MatchesController(ILogger<MatchesController> _logger, IMatchesService _matchesService)
        {
            logger = _logger;
            matchesService = _matchesService;
        }

        [Route("Matches")]
        public IActionResult Matches()
        {
            var matches = matchesService.GetAllMatches();
            return View(matches);
        }
    }
}
