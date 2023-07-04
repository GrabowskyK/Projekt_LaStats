using Microsoft.Identity.Client;
using System.ComponentModel;

namespace Projekt_LaStats.Models
{
    public class Player
    {
        public int Id { get; set; }
        public int? ShirtNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateBorn { get; set; }
        public PlayerPosition Position { get; set; }
        public int? Goals { get; set; } = 0;
        public int? Assist { get; set; } = 0;
        public int? Penalty { get; set; } = 0;
        public int? MinutesPenalty { get; set; } = 0;
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }


        public Player() { }

        public Player(string name, string surname, DateTime dateBorn, PlayerPosition position, int goals, int assist, int penalty, int minutesPenalty, int shirtNumber, int teamId)
        {
            Name = name;
            Surname = surname;
            DateBorn = dateBorn;
            Position = position;
            Goals = goals;
            Assist = assist;
            Penalty = penalty;
            MinutesPenalty = minutesPenalty;
            ShirtNumber = shirtNumber;
            TeamId = teamId;
        }
    }

    public enum PlayerPosition
    {
        Attack,
        Midfield,
        Defense,
        Goalie,
        Coach
    }
}
