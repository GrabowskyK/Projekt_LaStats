using Microsoft.AspNetCore.Mvc;
using Projekt_LaStats.Service;

namespace Projekt_LaStats.Controllers
{
    public class LeagueController : Controller
    {
        private readonly ILogger<LeagueController> logger;
        private readonly ILeagueService leagueService;

        public LeagueController(ILogger<LeagueController> _logger, ILeagueService _leagueService)
        {
            logger = _logger;
            leagueService = _leagueService;
        }
        [Route("League")]
        public IActionResult ShowLeagues()
        {
            var item = leagueService.GetAllLeagues().ToList();
            return View(item);
        }

    }
}
