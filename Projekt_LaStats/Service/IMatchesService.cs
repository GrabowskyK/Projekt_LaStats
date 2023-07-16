using Microsoft.AspNetCore.Mvc.Rendering;
using Projekt_LaStats.Models;

namespace Projekt_LaStats.Service
{
    public interface IMatchesService
    {
        IEnumerable<Match> GetAllMatches();
        List<SelectListItem> GetTeamsFromLeague(int id);
        void AddMatch(Match match);
        int GetLeagueId(int id);
    }
}
