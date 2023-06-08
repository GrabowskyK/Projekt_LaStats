
using Microsoft.AspNetCore.Mvc;
using Projekt_LaStats.Service;
using Projekt_LaStats.Models;
using System.Diagnostics;
using System.Data.Entity;
//using Microsoft.EntityFrameworkCore;

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
            List<Team> teams = teamService.GetTeamAndLeagues().ToList();
            return View(teams);
        }
       
        public IActionResult AddTeam()
        {
            List<Team> teams = teamService.GetTeamAndLeagues().ToList();
            return View(teams);
        }

        [HttpPost]
        public IActionResult AddTeam(Team team)
        {
            var team2 = team;
            return RedirectToAction("Teams");
        }

        [HttpPost]
        public IActionResult DeleteTeam(int id)
        {
            teamService.DeleteTeam(id);
            return RedirectToAction("Teams");
        }

        public IActionResult EditTeam(int id)
        {
            return View();
        }
    }
}
