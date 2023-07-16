using Humanizer;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IEnumerable<Team> GetAllTeams() => databaseContext.Team;
        public IEnumerable<Team> GetTeamAndLeagues() => databaseContext.Team.Include(t => t.League);
        public IEnumerable<Team> GetTeamByLeague(int id) => databaseContext.Team.Include(t => t.League).Where(t => t.Id == id);
        
        public void AddTeam(Team team)
        {
            var result = team;
            databaseContext.Team.Add(team);
            databaseContext.SaveChanges();
        }
        public void DeleteTeam(int id)
        {
            var team = databaseContext.Team.FirstOrDefault(t => t.Id == id);
            databaseContext.Remove(team);
            databaseContext.SaveChanges();
        }

        public IEnumerable<Team> TeamsInLeague(int id) => databaseContext.Team.Include(t => t.League).Where(t => t.LeagueId == id);
    }
}
