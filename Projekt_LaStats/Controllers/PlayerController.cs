using Microsoft.AspNetCore.Mvc;
using Projekt_LaStats.Models;
using Projekt_LaStats.Service;

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
            return View(playersInTeam);
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
            return RedirectToAction("AddPlayer");
        }
    }
}
