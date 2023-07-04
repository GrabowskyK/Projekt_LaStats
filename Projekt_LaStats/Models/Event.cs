using System.ComponentModel;

namespace Projekt_LaStats.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Time { get; set; }
        public int PlayerEventId { get; set; }
        public virtual Player PlayerEvent { get; set; }
        public EventType EventType { get; set; }
        
        public int? PlayerAssistId { get; set; }
        
        public virtual Player? PlayerAssist { get; set; }
        
        public PenaltyType? PenaltyType { get; set; }
        
        public int? PenaltyMinutes { get; set; }
        public int MatchId { get; set; }
        public virtual Match Match { get; set; }

        public Event() { }
        public Event(int id_player, string time, Player playerEvent, EventType eventType, int? id_player_assist, Player? playerAssist, PenaltyType? penaltyType, int? penalty_minutes, int id_match)
        {
            PlayerEventId = id_player;
            Time = time;
            PlayerEvent = playerEvent;
            EventType = eventType;
            PlayerAssistId = id_player_assist;
            PlayerAssist = playerAssist;
            PenaltyType = penaltyType;
            PenaltyMinutes = penalty_minutes;
            MatchId = id_match;
        }
    }

    public enum EventType
    {
        Gool,
        Penalty
    }
    public enum PenaltyType
    {
        Crosscheck,
        Bodycheck,
        Slashing,
        Tripping,
        Offside
    }
}
