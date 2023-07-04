using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Projekt_LaStats.Models;
using Projekt_LaStats.Service;
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
            //TODO: Sprawdzić czy dana drużyna istnieje
            ViewBag.TeamId = id;
            return View();
        }

        [HttpPost]
        public IActionResult AddPlayerPost(Player player)
        {
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
