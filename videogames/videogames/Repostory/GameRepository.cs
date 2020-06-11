using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using videogames.Model;
using videogames.Repostory.interfaces;
using videogames.Util;

namespace videogames.Repostory
{
    public class GameRepository : IGame
    {
        private readonly EntityDbContext _dbContext;

        public GameRepository(EntityDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }
        
        public IEnumerable<Game> findAll()
        {
            return _dbContext.games.ToList();
        }

        public Game findBy(long id)
        {
            return _dbContext.games.Find(id);
        }

        public long persist(Game game)
        {
            _dbContext.Add(game);
            save();
            return game.id;
        }

        public void upd(Game game)
        {
            _dbContext.Entry(game).State = EntityState.Modified;
            save();
        }

        public void save()
        {
            _dbContext.SaveChanges();
        }
    }
}