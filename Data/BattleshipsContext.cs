using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class BattleshipsContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}
