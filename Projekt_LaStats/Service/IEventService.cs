using Projekt_LaStats.Models;

namespace Projekt_LaStats.Service
{
    public interface IEventService
    {

        IEnumerable<Event> GetEventsFromMatch(int id);
    }
}
