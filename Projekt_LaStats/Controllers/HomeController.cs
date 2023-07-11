using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt_LaStats.Models;
using Projekt_LaStats.Service;
using System.Diagnostics;

namespace Projekt_LaStats.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService homeService;


        public HomeController(ILogger<HomeController> logger, IHomeService _homeService)
        {
            _logger = logger;
            homeService = _homeService;
        }

        public IActionResult Index()
        {
            var leagues = homeService.GetAllLeagues().ToList();
            return View(leagues);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}