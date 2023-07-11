using Projekt_LaStats.Context;
using Projekt_LaStats.Models;

namespace Projekt_LaStats.Service
{
    public class HomeService : IHomeService
    {

        private readonly DatabaseContext databaseContext;

        public HomeService(DatabaseContext _databaseContext)
        {
            databaseContext = _databaseContext;
        }

        public IEnumerable<League> GetAllLeagues() => databaseContext.Leagues;
    }
}
