using Projekt_LaStats.Context;
using Projekt_LaStats.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;

namespace Projekt_LaStats.Service
{
    public class MatchesService : IMatchesService
    {
        private readonly DatabaseContext databaseContext;

        public MatchesService(DatabaseContext _databaseContext)
        {
            databaseContext = _databaseContext;
        }

        public IEnumerable<Match> GetAllMatches() => databaseContext.Matches.Include(m => m.GuestTeam).Include(m => m.HomeTeam);
        public List<SelectListItem> GetTeams() => databaseContext.Team.Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Name }).ToList();

        public void AddMatch(Match match)
        {
            databaseContext.Matches.Add(match);
            databaseContext.SaveChanges();
        }
        public int GetLeagueId(int id)
        {
            var leagueId = databaseContext.Matches.Include(m => m.HomeTeam).Where(m => m.HomeTeam.Id == id).FirstOrDefault().HomeTeam.LeagueId;
            return leagueId;
        }
    }
}
