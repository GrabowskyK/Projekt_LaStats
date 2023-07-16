using Microsoft.AspNetCore.Mvc;
using Projekt_LaStats.Service;
using Projekt_LaStats.ViewModel;
using Projekt_LaStats.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

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
            PossibleToCreateMatchInEmptyMatch viewModel = new();
            
            var matchesFromLeague = matchesService.GetAllMatches().Where(m => m.HomeTeam.LeagueId == id).ToList();
            viewModel.matches = matchesFromLeague;
            viewModel.leagueId = id;
            return View(viewModel);
        }

        [Route("Matches/AddMatch")]
        public IActionResult AddMatch(int id)
        {
            CreateMatchVM viewModel = new CreateMatchVM();
            viewModel.teams = matchesService.GetTeamsFromLeague(id);
            viewModel.match = new Match();
            return View(viewModel);
        }

        [Route("Matches/AddMatchPost")]
        [HttpPost]
        public IActionResult AddMatchPost(CreateMatchVM viewModel)
        {
            viewModel.match.ScoreHomeTeam = 0;
            viewModel.match.ScoreGuestTeam = 0;
            viewModel.match.Date = new DateTime(viewModel.year, viewModel.month, viewModel.day, viewModel.hour, viewModel.minute, 0);
            matchesService.AddMatch(viewModel.match);
            var leagueId = matchesService.GetLeagueId(viewModel.match.HomeTeamId);
            return RedirectToAction("Matches", new {id = leagueId });
        }

        [HttpPost]
        public IActionResult GameEnded(int id)
        {
            matchesService.ChangeGameEnd(id);
            var leagueId = matchesService.GetLeagueIdFromMatchid(id);
            return RedirectToAction("InfoLeague", "Info", new { id = leagueId });
        }
    }
}
