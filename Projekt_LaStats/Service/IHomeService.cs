using Projekt_LaStats.Models;

namespace Projekt_LaStats.Service
{
    public interface IHomeService
    {
        IEnumerable<League> GetAllLeagues();

    }
}
