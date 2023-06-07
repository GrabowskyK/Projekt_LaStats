using System.ComponentModel.DataAnnotations;

namespace Projekt_LaStats.Models
{
    public class League
    {
        public int Id{ get; set; }
        public string Name { get; set; }

        public ICollection<Team> Teams { get; set; } //Relacja jeden do wielu, czyli jedna liga może być w wielu temach
    }
}
