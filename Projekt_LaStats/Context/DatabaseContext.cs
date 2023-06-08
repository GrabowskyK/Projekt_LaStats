using Microsoft.EntityFrameworkCore;
using Projekt_LaStats.Models;

namespace Projekt_LaStats.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Team> Team { get; set; }
        public DbSet<League> Leagues { get; set; }
    }
}
