using Microsoft.AspNetCore.Mvc;
using Projekt_LaStats.Service;
using Projekt_LaStats.ViewModel;
using Projekt_LaStats.Models;
using System.Text.RegularExpressions;

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
        public IActionResult Matches(int id)
        {
            var matches = matchesService.GetAllMatches().Where(m => m.HomeTeam.LeagueId == id);
            return View(matches);
        }

        [Route("Matches/AddMatch")]
        public IActionResult AddMatch()
        {
            CreateMatchVM viewModel = new CreateMatchVM();
            viewModel.teams = matchesService.GetTeams();
            viewModel.match = new Models.Match();
            return View(viewModel);
        }


        [HttpPost]
        public IActionResult AddMatchPost(Models.Match match)
        {
            var result = match;
            match.ScoreHomeTeam = 0;
            match.ScoreGuestTeam = 0;
            var xd = matchesService.GetAllMatches();
            return RedirectToAction("Matches");
        }
    }
}
