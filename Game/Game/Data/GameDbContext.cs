using Microsoft.EntityFrameworkCore;
using Game.Models;

namespace Game.Data
{
    public class GameDbContext : DbContext
    {
        public GameDbContext(DbContextOptions<GameDbContext> options) : base(options)
        {
        }

        public DbSet<Jogo> Jogos { get; set; }
    }
}
