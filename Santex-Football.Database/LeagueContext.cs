using Microsoft.EntityFrameworkCore;
using Santex_Football.Database.Models;

namespace Santex_Football.Database
{
    public class LeagueContext : DbContext
    {

        public LeagueContext(DbContextOptions<LeagueContext> options)
            : base(options)
        { }

        public DbSet<LeagueCode> LeagueCodes { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<LeagueTeam> LeagueTeam { get; set; }

        public DbSet<ImportedLeague> ImportedLeagues{ get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //LeagueTeam
            modelBuilder.Entity<LeagueTeam>()
                .HasKey(t => new { t.TeamId, t.LeagueId});
            
            modelBuilder.Entity<LeagueTeam>()
                .HasOne(lt => lt.League)
                .WithMany(l => l.LeagueTeams)
                .HasForeignKey(lt => lt.LeagueId);

            modelBuilder.Entity<LeagueTeam>()
                .HasOne(lt => lt.Team)
                .WithMany(l => l.LeagueTeams)
                .HasForeignKey(lt => lt.TeamId);

            //Player
            modelBuilder.Entity<Player>()
                .HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamId);

            base.OnModelCreating(modelBuilder);
        }


    }
}