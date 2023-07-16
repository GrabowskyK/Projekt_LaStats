using Microsoft.AspNetCore.Mvc.Rendering;
using Projekt_LaStats.Models;

namespace Projekt_LaStats.Service
{
    public interface IEventService
    {

        IEnumerable<Event> GetEventsFromMatch(int id);
        IEnumerable<Event> GetEventsFromMatchOnlyGoals(int id);
        IEnumerable<Event> GetEventsFromMatchOnlyFauls(int id);

        List<SelectListItem> GetTeamsInMatch(int id);
        List<SelectListItem> GetPlayersInTeam(int idHomeTeam, int idAwayTeam);
        void AddEvent(Event newEvent);
        void UpdateDataAboutPlayerStats(Event newEvent);
        void UpdateDataAboutScore(Event newEvent);
        void UpdateTeamBilance(Event newEvent);
        int GetLeagueId(int id);
    }
}
