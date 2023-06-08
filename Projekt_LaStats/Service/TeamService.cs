using Microsoft.EntityFrameworkCore;
using Projekt_LaStats.Context;
using Projekt_LaStats.Models;


namespace Projekt_LaStats.Service
{
    public class TeamService : ITeamService
    {
        private readonly DatabaseContext databaseContext;

        public TeamService(DatabaseContext _databaseContext)
        {
            databaseContext = _databaseContext;
        }

        public IEnumerable<Team> GetAllTeams() => databaseContext.Teams;
        public IEnumerable<Team> GetTeamAndLeagues() => databaseContext.Teams.Include(t => t.League);
        public IEnumerable<Team> GetTeamByLeague() => databaseContext.Teams.Where(t => t.LeagueId == t.League.Id);

        public void DeleteTeam(int id)
        {
            var team = databaseContext.Teams.FirstOrDefault(t => t.Id == id);
            databaseContext.Remove(team);
            databaseContext.SaveChanges();
        }
    }
}
