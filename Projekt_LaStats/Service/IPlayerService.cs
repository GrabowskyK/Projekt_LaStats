using Projekt_LaStats.Models;

namespace Projekt_LaStats.Service
{
    public interface IPlayerService 
    {
        IEnumerable<Player> GetPlayersFromTeam(int id);
        void AddPlayer(Player player);
    }
}
