namespace Projekt_LaStats.Models
{
    public class Match
    {
        public int Id { get; set; } 
        public int HomeTeamId { get; set; }
        public virtual Team HomeTeam { get; set; }
        public int GuestTeamId { get; set; }
        public virtual Team GuestTeam { get; set; }
        public DateTime Date { get; set; }
        public int ScoreHomeTeam { get; set; } = 0;
        public int ScoreGuestTeam { get;set; } = 0;
        public string Place { get; set; }


        public Match() { }

        public Match(int id_home_team, int id_guest_team, DateTime date,  int score_home_team, int score_guest_team, string place)
        {
            HomeTeamId = id_home_team;
            GuestTeamId = id_guest_team;
            Date = date;
            ScoreHomeTeam = score_home_team;
            ScoreGuestTeam = score_guest_team;
            Place = place;
        }
    }
}
