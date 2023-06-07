using Projekt_LaStats.Context;

namespace Projekt_LaStats.Service
{
    public class TeamService : ITeamService
    {
        private readonly DatabaseContext _databaseContext;

        public TeamService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
    }
}
