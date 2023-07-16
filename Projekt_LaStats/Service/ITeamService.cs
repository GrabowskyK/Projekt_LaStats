using Microsoft.AspNetCore.Mvc.Rendering;
using Projekt_LaStats.Models;

namespace Projekt_LaStats.Service
{
    public interface ITeamService
    {
        IEnumerable<Team> GetAllTeams();
        IEnumerable<Team> GetTeamAndLeagues();
        IEnumerable<Team> GetTeamByLeague(int id);
        IEnumerable<Team> TeamsInLeague(int id);
        void AddTeam(Team team);
        void DeleteTeam(int id);
    }
}
