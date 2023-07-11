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
            var teams = infoService.TeamsInLeagueStats(id).ToList();
            var players = infoService.GetScoredPlayers(id).Sum(p => p.Goals);
            return View(teams);
        }

        [Route("{id}/points")]
        public IActionResult InfoPlayerGoals(int id)
        {
            var players = infoService.GetScoredPlayers(id).Sum(p => p.Goals);
            return View(players);
        }
    }
}
