using FootballServerCapstone.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace FootballServerCapstone.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Club> Club { get; set; }
        public DbSet<History> History { get; set; }
        public DbSet<Loan> Loan { get; set; }
        public DbSet<Match> Match { get; set; }
        public DbSet<Performance> Performance { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<Season> Season { get; set; }

        public AppDbContext() : base()
        {

        }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(message => Debug.WriteLine(message), LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Performance>()
                .HasKey(p => new { p.MatchId, p.PlayerId });
            builder.Entity<Loan>()
                .HasOne(l => l.ParentClub)
                .WithMany(c => c.Loans);
            builder.Entity<Loan>()
                .HasOne(l => l.LoanClub);
            builder.Entity<Match>()
                .HasOne(m => m.HomeClub)
                .WithMany(c => c.HomeMatches);
            builder.Entity<Match>()
                .HasOne(m => m.VisitingClub)
                .WithMany(c => c.AwayMatches);
        }
    }
}
