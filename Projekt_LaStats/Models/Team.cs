using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_LaStats.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public League League { get; set; }
    }
}
