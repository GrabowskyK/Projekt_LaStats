using Projekt_LaStats.Context;
using Projekt_LaStats.Models;
using Microsoft.EntityFrameworkCore;

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

        public IEnumerable<Event> GetEventsFromMatchOnlyGoals(int id) => databaseContext.Events.Where(e => e.MatchId == id && e.EventType == (EventType)0).Include(e => e.PlayerEvent).Include(e => e.PlayerAssist).ThenInclude(p => p.Team);
        public IEnumerable<Event> GetEventsFromMatchOnlyFauls(int id) => databaseContext.Events.Where(e => e.MatchId == id && e.EventType == (EventType)1).Include(e => e.PlayerEvent).ThenInclude(p => p.Team);

    }
}
