using Microsoft.AspNetCore.Mvc.Rendering;
using Projekt_LaStats.Models;

namespace Projekt_LaStats.ViewModel
{
    public class CreateEventVM
    {

        public Event NewEvent { get; set; }
        public List<SelectListItem> teamsInMatch { get; set; }
        public List<SelectListItem> playersInMatch { get; set; }
        public int MatchId { get; set; }
    }
}
