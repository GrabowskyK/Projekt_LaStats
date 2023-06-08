
using Microsoft.AspNetCore.Mvc;
using Projekt_LaStats.Service;
using Projekt_LaStats.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Projekt_LaStats.Controllers
{
    public class TeamController : Controller
    {
        private readonly ILogger<TeamController> logger;
        private readonly ITeamService teamService;

        public TeamController(ILogger<TeamController> _logger, ITeamService _teamService)
        {
            logger = _logger;
            teamService = _teamService;
        }

        [Route("Teams")]
        public IActionResult Teams()
        {
            return View(teamService.GetAllTeams());
        }

        public IActionResult AddTeam()
        {
            return View();
        }

        public IActionResult RemoveTeam()
        {
            return View();
        }

        public IActionResult EditTeam()
        {
            return View();
        }
    }
}
