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

        public void DeleteTeam(int id)
        {
            var team = databaseContext.Team.FirstOrDefault(t => t.Id == id);
            databaseContext.Remove(team);
            databaseContext.SaveChanges();
        }
    }
}
