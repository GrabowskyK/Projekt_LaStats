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
        
        public int wins { get; set; }
        public int draw { get; set; }
        public int lose { get; set; }

        public ICollection<Match> TeamHost { get; set; }
        public ICollection<Match> TeamAway { get; set; }
        public Team() { }

        public Team(string name, string shortName, int leagueId)
        {
            Name = name;
            ShortName = shortName;
            LeagueId = leagueId;
        }
    }
}
