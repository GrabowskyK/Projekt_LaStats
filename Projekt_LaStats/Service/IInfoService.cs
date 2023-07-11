using Projekt_LaStats.Models;

namespace Projekt_LaStats.Service
{
    public interface IInfoService
    {
        IEnumerable<Team> TeamsInLeagueStats(int id);
        IEnumerable<Player> GetScoredPlayers(int id);
    }
}
