using Microsoft.EntityFrameworkCore;
using Pr29_Radosteva.Classes.Database;
using Pr29_Radosteva.Models;

namespace Pr29_Radosteva.Context
{
    public class CalendarContext : DbContext
    {
        public DbSet<Events> Events { get; set; }
        public DbSet<Participants> Participants { get; set; }
        public CalendarContext()
        {
            Database.EnsureCreated();
            Events.Load();
            Participants.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(Config.connection, Config.version);
        }
    }
}
