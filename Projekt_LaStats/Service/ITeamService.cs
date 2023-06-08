using Projekt_LaStats.Models;

namespace Projekt_LaStats.Service
{
    public interface ITeamService
    {
        IEnumerable<Team> GetAllTeams();
        IEnumerable<Team> GetTeamAndLeagues();
        void DeleteTeam(int id);
    }
}
