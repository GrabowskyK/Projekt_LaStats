using Microsoft.AspNetCore.Mvc.Rendering;
using Projekt_LaStats.Models;

namespace Projekt_LaStats.ViewModel
{
    public class CreatePlayerVM
    {
        public Player player { get; set; }

        public int TeamId { get; set; }
        public int day { get; set; }
        public int month { get; set; }
        public int year { get; set; }
    }
}
