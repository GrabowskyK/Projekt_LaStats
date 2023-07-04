using Microsoft.AspNetCore.Mvc.Rendering;
using Projekt_LaStats.Models;

namespace Projekt_LaStats.ViewModel
{
    public class CreateTeamVM
    {
        public Team NewTeam { get; set; }
        public List<SelectListItem> leagues { get; set; }
    }
}
