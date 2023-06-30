using Projekt_LaStats.Context;
using Projekt_LaStats.Models;
using Microsoft.EntityFrameworkCore;

namespace Projekt_LaStats.Service
{
    public class PlayerService : IPlayerService
    {
        private readonly DatabaseContext databaseContext;

        public PlayerService(DatabaseContext _databaseContext)
        {
            databaseContext = _databaseContext;
        } 

        public IEnumerable<Player> GetPlayersFromTeam(int id) => databaseContext.Players.Include(p => p.Team).Where(p => p.TeamId == id);
        public void AddPlayer(Player player)
        {
            databaseContext.Add(player);
            databaseContext.SaveChanges();
        }

        //TODO: Sprawdzić czy dana drużyna istnieje
    }
}
