using Projekt_LaStats.Models;

namespace Projekt_LaStats.ViewModel
{
    public class EventDisplayVM
    {
        public IEnumerable<Event> eventGool { get; set; }
        public IEnumerable<Event> eventFaul { get; set; }
    }
}
