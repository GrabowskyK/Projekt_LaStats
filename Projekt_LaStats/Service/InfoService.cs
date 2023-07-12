using Projekt_LaStats.Context;
using Projekt_LaStats.Models;
using Microsoft.EntityFrameworkCore;

namespace Projekt_LaStats.Service
{
    public class InfoService : IInfoService
    {

        private readonly DatabaseContext databaseContext;

        public InfoService(DatabaseContext _databaseContext)
        {
            databaseContext = _databaseContext;
        }

        public IEnumerable<Team> TeamsInLeagueStats(int id) => databaseContext.Team.Where(t => t.LeagueId == id);
        public IEnumerable<Player> GetScoredPlayers(int id) => databaseContext.Players.Include(p => p.Team).Where(p => p.Goals > 0).Where(p => p.Team.LeagueId == id).OrderByDescending(p => p.Points);
        public IEnumerable<Player> GetPenaltyPlayers(int id) => databaseContext.Players.Where(p => p.Penalty > 0).Include(p => p.Team).Where(p => p.Team.LeagueId == id).OrderByDescending(p => p.MinutesPenalty);

    }
}
