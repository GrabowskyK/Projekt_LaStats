using Projekt_LaStats.Models;

namespace Projekt_LaStats.Service
{
    public interface ITeamService
    {
        IEnumerable<Team> GetAllTeams();
        IEnumerable<Team> GetTeamAndLeagues();
        IEnumerable<Team> GetTeamByLeague(int id);
        void DeleteTeam(int id);
    }
}
