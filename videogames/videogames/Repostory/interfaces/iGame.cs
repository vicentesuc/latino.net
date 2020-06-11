using System.Collections.Generic;
using videogames.Model;

namespace videogames.Repostory.interfaces
{
    public interface IGame
    {
        
        IEnumerable<Game> findAll();

        Game findBy(long id);
        
        long persist(Game videogame);
        
        void upd(Game address);
        
        void save();
    }
}