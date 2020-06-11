using Microsoft.EntityFrameworkCore;
using videogames.Model;

namespace videogames.Util
{
    public class EntityDbContext : DbContext
    {
        public EntityDbContext(DbContextOptions<EntityDbContext> options) : base(options) { }
        
        public DbSet<Game> games { get; set; }
    }
}