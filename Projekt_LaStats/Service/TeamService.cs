using Projekt_LaStats.Context;
using Projekt_LaStats.Models;

namespace Projekt_LaStats.Service
{
    public class TeamService : ITeamService
    {
        private readonly DatabaseContext _databaseContext;

        public TeamService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IEnumerable<Team> GetAllTeams() => _databaseContext.Team;

    }
}
