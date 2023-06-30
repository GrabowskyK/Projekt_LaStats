using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Projekt_LaStats.Models;
using System.Xml;

namespace Projekt_LaStats.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.HomeTeam)
                .WithMany(t => t.TeamHost)
                .HasForeignKey(m => m.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.GuestTeam)
                .WithMany(t => t.TeamAway)
                .HasForeignKey(m => m.GuestTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Player>()
                .Property(e => e.Goals)
                .HasDefaultValue(0);

            modelBuilder.Entity<Player>()
                .Property(e => e.Assist)
                .HasDefaultValue(0);

            modelBuilder.Entity<Player>()
                .Property(e => e.Penalty)
                .HasDefaultValue(0);

            modelBuilder.Entity<Player>()
                .Property(e => e.MinutesPenalty)
                .HasDefaultValue(0);

            //modelBuilder.Entity<Event>()
            //    .HasOne(e => e.PlayerEvent)
            //    .WithMany(p => p.PlayerEvent)
            //    .HasForeignKey(e => e.PlayerEventId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Event>()
            //    .HasOne(e => e.PlayerAssist)
            //    .WithMany(p => p.PlayerAssist)
            //    .HasForeignKey(e => e.PlayerAssistId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Event>()
            //    .HasOne(e => e.Team)
            //    .WithMany(t => t.Events)
            //    .HasForeignKey(e => e.TeamId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Event>()
            //    .HasOne(e => e.Match)
            //    .WithMany(m => m.Events)
            //    .HasForeignKey(e => e.MatchId)
            //    .OnDelete(DeleteBehavior.Restrict);


        }

        public DbSet<Team> Team { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Event> Events { get; set; }

        
    }
}
