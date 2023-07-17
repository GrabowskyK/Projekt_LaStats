using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Projekt_LaStats.Models;
using Projekt_LaStats.Service;
using Projekt_LaStats.ViewModel;
using System.Numerics;

namespace Projekt_LaStats.Controllers
{
    public class PlayerController : Controller
    {
        private readonly ILogger<PlayerController> logger;
        private readonly IPlayerService playerService;

        public PlayerController(ILogger<PlayerController> _logger, IPlayerService _playerService)
        {
            logger = _logger;
            playerService = _playerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Teams/{id}")]
        public IActionResult PlayersInTeam(int id)
        {
            List<Player> playersInTeam = playerService.GetPlayersFromTeam(id).ToList();
            if (playersInTeam.Any())
            {
                return View(playersInTeam);
            }
            else
            {
               return RedirectToAction("AddPlayer", new { id = id });
            }
                
        }
        [Route("Teams/{id}/AddPlayer")]
        public IActionResult AddPlayer(int id)
        {
            CreatePlayerVM viewModel = new();
            viewModel.TeamId = id;
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddPlayerPost(CreatePlayerVM playerVM)
        {
            DateTime time = new(playerVM.year, playerVM.month, playerVM.day);
            Player player = new(playerVM.player.Name, playerVM.player.Surname, time, playerVM.player.Position, 0, 0, 0, 0, (int)playerVM.player.ShirtNumber, playerVM.TeamId);
            playerService.AddPlayer(player);
            return RedirectToAction("PlayersInTeam", new { id = player.TeamId });
        }

        [HttpPost]
        public IActionResult DeletePlayer(int playerId, int teamId)
        {
            playerService.DeletePlayerById(playerId);
            return RedirectToAction("PlayersInTeam", new { id =  teamId});
        }
    }
}
