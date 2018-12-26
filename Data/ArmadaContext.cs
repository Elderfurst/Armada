using Data.Entities;
using Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ArmadaContext : DbContext
    {
        public ArmadaContext(DbContextOptions<ArmadaContext> options) : base(options) { }

        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .Property(g => g.Height)
                .HasDefaultValue(100)
                .IsRequired();
            modelBuilder.Entity<Game>()
                .Property(g => g.Width)
                .HasDefaultValue(100)
                .IsRequired();
            modelBuilder.Entity<Game>()
                .Property(g => g.GameStatus)
                .HasDefaultValue(GameStatus.ACTIVE)
                .IsRequired();

            modelBuilder.Entity<Player>()
                .Property(p => p.AuthorizationCode)
                .IsRequired();
            modelBuilder.Entity<Player>()
                .Property(p => p.DisplayName)
                .IsRequired();

            modelBuilder.Ignore<Action>();
        }
    }
}
