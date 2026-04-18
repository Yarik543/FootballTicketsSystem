using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FootballTicketsSystem.DBModels
{
    public partial class FootBallTicketsDB : DbContext
    {
        public FootBallTicketsDB()
            : base("name=FootBallTicketsDB")
        {
        }

        public virtual DbSet<Coaches> Coaches { get; set; }
        public virtual DbSet<Matches> Matches { get; set; }
        public virtual DbSet<Players> Players { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Stadiums> Stadiums { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }
        public virtual DbSet<Tickets> Tickets { get; set; }
        public virtual DbSet<Transfers> Transfers { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UserTickets> UserTickets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Matches>()
                .Property(e => e.RatingMatch)
                .HasPrecision(4, 2);

            modelBuilder.Entity<Matches>()
                .HasMany(e => e.Tickets)
                .WithOptional(e => e.Matches)
                .HasForeignKey(e => e.MatchId);

            modelBuilder.Entity<Players>()
                .HasMany(e => e.Transfers)
                .WithOptional(e => e.Players)
                .HasForeignKey(e => e.PlayerId);

            modelBuilder.Entity<Roles>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.Roles)
                .HasForeignKey(e => e.RoleId);

            modelBuilder.Entity<Stadiums>()
                .HasMany(e => e.Matches)
                .WithOptional(e => e.Stadiums)
                .HasForeignKey(e => e.StadiumId);

            modelBuilder.Entity<Stadiums>()
                .HasMany(e => e.Teams)
                .WithOptional(e => e.Stadiums)
                .HasForeignKey(e => e.StadiumId);

            modelBuilder.Entity<Teams>()
                .HasMany(e => e.Coaches)
                .WithRequired(e => e.Teams)
                .HasForeignKey(e => e.TeamId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teams>()
                .HasMany(e => e.Matches)
                .WithOptional(e => e.Teams)
                .HasForeignKey(e => e.TeamHomeId);

            modelBuilder.Entity<Teams>()
                .HasMany(e => e.Matches1)
                .WithOptional(e => e.Teams1)
                .HasForeignKey(e => e.TeamAwayId);

            modelBuilder.Entity<Teams>()
                .HasMany(e => e.Players)
                .WithOptional(e => e.Teams)
                .HasForeignKey(e => e.TeamId);

            modelBuilder.Entity<Teams>()
                .HasMany(e => e.Transfers)
                .WithOptional(e => e.Teams)
                .HasForeignKey(e => e.ToTeamId);

            modelBuilder.Entity<Tickets>()
                .Property(e => e.Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Tickets>()
                .HasMany(e => e.UserTickets)
                .WithOptional(e => e.Tickets)
                .HasForeignKey(e => e.TicketId);

            modelBuilder.Entity<Transfers>()
                .Property(e => e.Price)
                .HasPrecision(12, 2);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.UserTickets)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.UserId);
        }
    }
}
