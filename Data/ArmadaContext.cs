using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ArmadaContext : DbContext
    {
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
        }
    }
}
