using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt_LaStats.Models;
using Projekt_LaStats.ViewModel;
using Projekt_LaStats.Service;
using System.Diagnostics;

namespace Projekt_LaStats.Controllers
{
    public class InfoController : Controller
    {
        private readonly ILogger<InfoController> logger;
        private readonly IInfoService infoService;

        public InfoController(ILogger<InfoController> _logger, IInfoService _infoService)
        {
            logger = _logger;
            infoService = _infoService;
        }

        [Route("{id}")]
        public IActionResult InfoLeague(int id)
        {
            PossibleToCreateTeamInEmptyLeague viewModel = new PossibleToCreateTeamInEmptyLeague();

            var teams = infoService.TeamsInLeagueStats(id).ToList();
            viewModel.id = id;
            if(teams != null)
            {
                viewModel.team = teams;
                return View(viewModel);
            }
            return View(viewModel);
            
        }

        [Route("{id}/points")]
        public IActionResult InfoPlayer(int id)
        {
            var players = infoService.GetScoredPlayers(id);
            ViewBag.Id = id;
            return View(players);
        }

        [Route("{id}/penalty")]
        public IActionResult InfoPlayerPenalty(int id)
        {
            var players = infoService.GetPenaltyPlayers(id);
            ViewBag.Id = id;
            return View(players);
        }
    }
}
