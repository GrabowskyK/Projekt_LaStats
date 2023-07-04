
using Microsoft.AspNetCore.Mvc;
using Projekt_LaStats.Service;
using Projekt_LaStats.Models;
using Projekt_LaStats.ViewModel;
using System.Diagnostics;
using System.Data.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [Route("Teams/League_{id}")]
        public IActionResult TeamsInLeague(int id)
        {
            List<Team> teamsInLeague = teamService.TeamsInLeague(id).ToList();
            return View("~/Views/Team/Teams.cshtml", teamsInLeague);
        }


        public IActionResult AddTeam()
        {
            List<SelectListItem> NameLeague = teamService.LeaguesNames().ToList();
            CreateTeamVM viewModel = new CreateTeamVM();
            viewModel.NewTeam = new Team();
            viewModel.leagues = NameLeague;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddTeam(CreateTeamVM createTeamVM)
        {
            Team team = new(createTeamVM.NewTeam.Name, createTeamVM.NewTeam.ShortName, createTeamVM.NewTeam.LeagueId);
            teamService.AddTeam(team);
            return RedirectToAction("Teams");
        }

        [HttpPost]
        public IActionResult DeleteTeam(int id)
        {
            teamService.DeleteTeam(id);
            return RedirectToAction("Teams");
        }
        

    }
}
