using Microsoft.AspNetCore.Mvc.Rendering;
using Projekt_LaStats.Models;

namespace Projekt_LaStats.ViewModel
{
    public class CreateMatchVM
    {
        public Match match { get; set; }
        public List<SelectListItem> teams { get; set; }

    }
}
