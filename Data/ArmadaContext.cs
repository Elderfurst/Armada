using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ArmadaContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}
