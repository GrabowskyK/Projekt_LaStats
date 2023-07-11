using Projekt_LaStats.Context;
using Projekt_LaStats.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

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
    }
}
