using Microsoft.AspNetCore.Mvc;
using Projekt_LaStats.Service;
using Projekt_LaStats.ViewModel;
using Projekt_LaStats.Models;

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
            viewModel.match = new Match();
            return View(viewModel);
        }

        [Route("Matches/AddMatchPost")]
        [HttpPost]
        public IActionResult AddMatchPost(CreateMatchVM viewModel)
        {
            viewModel.match.ScoreHomeTeam = 0;
            viewModel.match.ScoreGuestTeam = 0;
            viewModel.match.Date = new DateTime(viewModel.year, viewModel.month, viewModel.day);
            matchesService.AddMatch(viewModel.match);
            var leagueId = matchesService.GetLeagueId(viewModel.match.HomeTeamId);
            return RedirectToAction("Matches", new {id = leagueId });
        }
    }
}
