using Projekt_LaStats.Context;
using Projekt_LaStats.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Projekt_LaStats.Service
{
    public class EventService : IEventService
    {
        private readonly DatabaseContext databaseContext;

        public EventService(DatabaseContext _databaseContext)
        {
            databaseContext = _databaseContext;
        }

        public IEnumerable<Event> GetEventsFromMatch(int id) => databaseContext.Events.Where(e => e.MatchId == id).Include(e => e.PlayerEvent).Include(e => e.PlayerAssist);

        public IEnumerable<Event> GetEventsFromMatchOnlyGoals(int id) => databaseContext.Events
            .Where(e => e.MatchId == id && e.EventType == (EventType)0)
            .Include(e => e.PlayerEvent)
                .ThenInclude(p => p.Team)
            .Include(e => e.PlayerAssist)
                .ThenInclude(pl => pl.Team)
            .Include(e => e.Match);
        public IEnumerable<Event> GetEventsFromMatchOnlyFauls(int id) => databaseContext.Events
            .Where(e => e.MatchId == id && e.EventType == (EventType)1)
            .Include(e => e.PlayerEvent)
                .ThenInclude(p => p.Team);

        public List<SelectListItem> LeaguesNames() => databaseContext.Leagues
            .Select(l => new SelectListItem { Value = l.Id.ToString(), Text = l.Name }).ToList();

        public List<SelectListItem> GetTeamsInMatch(int id) => databaseContext.Matches
        .Include(m => m.HomeTeam)
        .Include(m => m.GuestTeam)
        .Where(m => m.Id == id)
        .Select(m => new SelectListItem
        {
            Value = m.HomeTeam.Id.ToString(),
            Text = m.HomeTeam.Name
        })
        .Concat(databaseContext.Matches
            .Include(m => m.HomeTeam)
            .Include(m => m.GuestTeam)
            .Where(m => m.Id == id)
            .Select(m => new SelectListItem
            {
                Value = m.GuestTeam.Id.ToString(),
                Text = m.GuestTeam.Name
            }))
        .ToList();


        public List<SelectListItem> GetPlayersInTeam(int idHomeTeam, int idAwayTeam) => databaseContext.Players
            .Where(p => p.TeamId == idHomeTeam || p.TeamId == idAwayTeam)
            .Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = $"#{p.ShirtNumber} {p.Name} {p.Surname}"
            }).ToList();
    
        public void AddEvent(Event newEvent)
        {
            databaseContext.Events.Add(newEvent);
            databaseContext.SaveChanges();
        }
        
        public void UpdateDataAboutPlayerStats(Event newEvent){
            var record = databaseContext.Players.Where(p => p.Id == newEvent.PlayerEventId).FirstOrDefault();
            if (newEvent.EventType == (EventType)0)
            {
                record.Goals += 1;
                if(newEvent.PlayerAssistId != null)
                {
                    var recordAssist = databaseContext.Players.Where(p => p.Id == newEvent.PlayerAssistId).FirstOrDefault();
                    recordAssist.Assist += 1;
                }
            }
            else if(newEvent.EventType == (EventType)1)
            {
                record.Penalty += 1;
                record.MinutesPenalty += newEvent.PenaltyMinutes;
            }
            databaseContext.SaveChanges();
        }
    }
}
