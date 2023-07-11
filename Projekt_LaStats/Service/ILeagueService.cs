using Projekt_LaStats.Models;

namespace Projekt_LaStats.Service
{
    public interface ILeagueService
    {
        IEnumerable<League> GetAllLeagues();
        void CreateLeague(League league);
    }
}