﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projekt_LaStats.Models;
using Projekt_LaStats.Service;
using Projekt_LaStats.ViewModel;
using System.Collections.Generic;

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
            viewModel.MatchId = id;
            return View(viewModel);
        }

        [Route("Matches/{id}/AddEvent")]
        public IActionResult AddEvent(int id)
        {
            CreateEventVM viewModel = new CreateEventVM();
            var teams = eventService.GetTeamsInMatch(id);
            var players = eventService.GetPlayersInTeam(Int32.Parse(teams[0].Value), Int32.Parse(teams[1].Value));
            viewModel.NewEvent = new Event();
            viewModel.teamsInMatch = teams;
            viewModel.playersInMatch = players;
            viewModel.MatchId = id;
            

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddEventPost(Event newEvent){
            eventService.AddEvent(newEvent);
            eventService.UpdateDataAboutPlayerStats(newEvent);
            eventService.UpdateDataAboutScore(newEvent);
            return RedirectToAction("EventsInMatch", new { id = newEvent.MatchId });
        }
    }
}
