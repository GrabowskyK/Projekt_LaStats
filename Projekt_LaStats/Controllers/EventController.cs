using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projekt_LaStats.Models;
using Projekt_LaStats.Service;
using Projekt_LaStats.ViewModel;

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
            EventDisplayVM viewModel = new EventDisplayVM();
            viewModel.eventGool = eventService.GetEventsFromMatchOnlyGoals(id);
            viewModel.eventFaul = eventService.GetEventsFromMatchOnlyFauls(id);
            return View(viewModel);
        }
    }
}
