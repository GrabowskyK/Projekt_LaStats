﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_LaStats.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LeagueId { get; set; }
        public virtual League League { get; set; }
        public Team() { }

        public Team(string name)
        {
            Name = name;
        }
    }
}
