namespace Projekt_LaStats.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Date_born { get; set; }
        public PlayerPosition Position { get; set; }
        public int Goals { get; set; } = 0;
        public int Assist { get; set; } = 0;
        public int Penalty { get; set; } = 0;
        public int Minutes_penalty { get; set; } = 0;
        public int Id_team { get; set; }
        public virtual Team Team { get; set; }

        public Player() { }

        public Player(string name, string surname, DateTime date_born, PlayerPosition position, int goals, int assist, int penalty, int minutes_penalty, int id_team, Team team)
        {
            Name = name;
            Surname = surname;
            Date_born = date_born;
            Position = position;
            Goals = goals;
            Assist = assist;
            Penalty = penalty;
            Minutes_penalty = minutes_penalty;
            Id_team = id_team;
            Team = team;
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
