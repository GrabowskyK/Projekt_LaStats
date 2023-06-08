using System.ComponentModel.DataAnnotations;

namespace Projekt_LaStats.Models
{
    public class League
    {
        public int Id{ get; set; }
        public string Name { get; set; }

        public League() { }

        public League(string name)
        {
            Name = name;
        }
    }
}
