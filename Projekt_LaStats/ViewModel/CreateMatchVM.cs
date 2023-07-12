using Microsoft.AspNetCore.Mvc.Rendering;
using Projekt_LaStats.Models;

namespace Projekt_LaStats.ViewModel
{
    public class CreateMatchVM
    {
        public Match match { get; set; }
        public List<SelectListItem> teams { get; set; }

        public int day { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public int hour { get; set; }
        public int minute { get; set; }
    }
}
