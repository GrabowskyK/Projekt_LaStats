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

        public IEnumerable<Event> GetEventsFromMatch(int id) => databaseContext.Events.Where(e => e.MatchId == id);
    }
}
