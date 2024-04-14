using Microsoft.EntityFrameworkCore;
using RouletteGameAPI.Models;

namespace RouletteGameAPI.Databases
{
    public class ApiDbContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
    {
        public DbSet<Roulette> Roulette { get; set; }
        public DbSet<Bet> Bet { get; set; }
    }
}