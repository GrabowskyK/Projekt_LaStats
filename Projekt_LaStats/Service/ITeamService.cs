using Projekt_LaStats.Models;

namespace Projekt_LaStats.Service
{
    public interface ITeamService
    {
        IEnumerable<Team> GetAllTeams();
    }
}
