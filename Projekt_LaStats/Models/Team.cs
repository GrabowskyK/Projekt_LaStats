using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_LaStats.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [MaxLength(3)]
        public string ShortName { get; set; }
        public int LeagueId { get; set; }
        public virtual League League { get; set; }

        public ICollection<Match> TeamHost { get; set; }
        public ICollection<Match> TeamAway { get; set; }
        public Team() { }

        public Team(string name, int leagueId)
        {
            Name = name;
            LeagueId = leagueId;
        }
    }
}
