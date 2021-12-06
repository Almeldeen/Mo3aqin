using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mo3aqin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mo3aqin.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<GameDetails> GameDetails { get; set; }
        public DbSet<Championship> Championships { get; set; }
        public DbSet<Coach_Emp_Games> Coach_Emp_Games { get; set; }
        public DbSet<ChampionshipGames> ChampionshipGames { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerGames> PlayerGames { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<ChampStatus> ChampStatuses { get; set; }
        public DbSet<ChampPLayers> ChampPLayers { get; set; }
        public DbSet<Champ> champs { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<PlayerDecision> playerDecisions { get; set; }
        public DbSet<CoachDecision> CoachDecisions { get; set; }
        public DbSet<PlayerHistory> PlayerHistories { get; set; }
        public DbSet<EmployeeDecision> EmployeeDecisions { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Coach_Emp_Games>()
               .HasKey(b => new { b.CoachId, b.GameId, b.EmpId })
               .HasName("PK_Coach_Emp_Games");
            builder.Entity<GameDetails>()
              .HasKey(b => new { b.CoachId, b.GameId, b.EmpId, b.CoachAssId, b.SupervisorId })
              .HasName("PK_GameDetails");

            builder.Entity<PlayerGames>()
             .HasKey(b => new { b.GameId, b.PlayerId })
             .HasName("PK_PlayerGames");
            builder.Entity<ChampPLayers>()
             .HasKey(b => new { b.ChampId, b.PlayerId })
             .HasName("PK_ChampPLayers");
            builder.Entity<Game>()
                .HasMany(d => d.Championships)
                .WithMany(x => x.Games)
                .UsingEntity<ChampionshipGames>(
                j => j
                .HasOne(pt => pt.Championship)
                .WithMany(t => t.ChampionshipGames)
                .HasForeignKey(pt => pt.ChampId),
                j => j
                .HasOne(pt => pt.Game)
                .WithMany(t => t.ChampionshipGames)
                .HasForeignKey(pt => pt.GameId),
                j=> j
                .HasKey(t=> new {t.GameId,t.ChampId })
                );
            builder.Entity<IdentityUser>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
        }
    }
}
