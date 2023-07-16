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
        public List<SelectListItem> GetTeamsFromLeague(int id) => databaseContext.Team.Where(t => t.LeagueId == id).Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Name }).ToList();

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

        public int GetLeagueIdFromMatchid(int id) => databaseContext.Matches.Include(m => m.HomeTeam).Where(m => m.Id == id).Select(t => t.HomeTeam.LeagueId).FirstOrDefault();

        public void ChangeGameEnd(int id)
        {
            var match = databaseContext.Matches.Where(m => m.Id == id);
            if(match.FirstOrDefault().IsEnded == false)
            {
                match.FirstOrDefault().IsEnded = true;
            }
            else
            {
                match.FirstOrDefault().IsEnded = false;
            }
            databaseContext.SaveChanges();
            
        }
    }
}
