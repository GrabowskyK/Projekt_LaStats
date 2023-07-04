using Microsoft.AspNetCore.Mvc;
using Projekt_LaStats.Models;
using Projekt_LaStats.Service;


namespace Projekt_LaStats.Controllers
{
    public class EventController : Controller
    {
        private readonly ILogger<EventController> logger;
        private readonly IEventService eventService;

        public EventController(ILogger<EventController> _logger, IEventService _eventService)
        {
            logger = _logger;
            eventService = _eventService;
        }

        [Route("Matches/{id}")]
        public IActionResult EventsInMatch(int id)
        {
            var events = eventService.GetEventsFromMatch(id);
            return View(events);
        }
    }
}
