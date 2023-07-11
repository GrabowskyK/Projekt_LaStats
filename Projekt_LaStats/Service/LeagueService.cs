using Microsoft.AspNetCore.Mvc;
using Projekt_LaStats.Context;
using Projekt_LaStats.Models;
using Microsoft.EntityFrameworkCore;

namespace Projekt_LaStats.Service
{
    public class LeagueService : ILeagueService
    {
        private readonly DatabaseContext databaseContext;

        public LeagueService(DatabaseContext _databaseContext)
        {
            databaseContext = _databaseContext;
        }

        public IEnumerable<League> GetAllLeagues() => databaseContext.Leagues;

        public void CreateLeague(League league)
        {
            databaseContext.Leagues.Add(league);
            databaseContext.SaveChanges();
        }
    }
}
