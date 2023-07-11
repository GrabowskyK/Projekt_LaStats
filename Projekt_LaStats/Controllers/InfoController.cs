using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt_LaStats.Models;
using Projekt_LaStats.Service;
using System.Diagnostics;

namespace Projekt_LaStats.Controllers
{
    public class InfoController
    {
        private readonly ILogger<InfoController> logger;
        private readonly IInfoService infoService;

        public InfoController(ILogger<InfoController> _logger, IInfoService _infoService)
        {
            logger = _logger;
            infoService = _infoService;
        }

        //public IActionResult InfoLeague()
        //{

        //    return View();
        //}
    }
}
