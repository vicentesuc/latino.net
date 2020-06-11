using System;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using videogames.Model;
using videogames.Repostory.interfaces;

namespace videogames.Controllers
{
    [Route("rest/game")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGame _game;


        public GameController(IGame game)
        {
            _game = game;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            Log.Information("test services");
            var games = _game.findAll();
            return new OkObjectResult(games);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] long id)
        {
            var game = _game.findBy(id);
            return new OkObjectResult(game);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] Game game)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    long last_id = _game.persist(game);
                    scope.Complete();
                    return StatusCode(201, last_id);
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error" + ex.Message);
                
                return new NoContentResult();
            }
        }
        
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Game game,[FromRoute] int id )
        {
            if (id != game.id) { return StatusCode(204); }

            using (var scope = new TransactionScope())
            {
                _game.upd(game);
                scope.Complete();
                return new OkResult();
            }
        }
    }
}