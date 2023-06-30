using Microsoft.EntityFrameworkCore;
using Projekt_LaStats.Context;
using Projekt_LaStats.Models;
using Microsoft.EntityFrameworkCore;

namespace Projekt_LaStats.Service
{
    public class TeamService : ITeamService
    {
        private readonly DatabaseContext databaseContext;

        public TeamService(DatabaseContext _databaseContext)
        {
            databaseContext = _databaseContext;
        }

        public IEnumerable<Team> GetAllTeams() => databaseContext.Team;
        public IEnumerable<Team> GetTeamAndLeagues() => databaseContext.Team.Include(t => t.League);
        public IEnumerable<Team> GetTeamByLeague(int id) => databaseContext.Team.Include(t => t.League).Where(t => t.Id == id);
        

        public void DeleteTeam(int id)
        {
            var team = databaseContext.Team.FirstOrDefault(t => t.Id == id);
            databaseContext.Remove(team);
            databaseContext.SaveChanges();
        }
    }
}
