using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Game.Models;

namespace Game.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        private static List<Jogo> games = new List<Jogo>
        {
            new Jogo("Hollow Knight", "Metroidvania", "Team Cherry"),
            new Jogo("The Last Of Us: Part I", "Ação", "Naughty Dog"),
            new Jogo("Elden Ring", "RPG", "From Software")
        };

        // GET: api/Game
        [HttpGet]
        public ActionResult<IEnumerable<Jogo>> Get()
        {
            return Ok(games);
        }

        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Jogo> Get(int id)
        {
            if (id < 0 || id >= games.Count)
            {
                return NotFound();
            }

            return Ok(games[id]);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Jogo game)
        {
            games.Add(game);
            return CreatedAtAction(nameof(Get), new { id = games.IndexOf(game) }, game);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Jogo game)
        {
            if (id < 0 || id >= games.Count)
            {
                return NotFound();
            }

            games[id] = game;
            return NoContent();
        }

        // DELETE: api/Game/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id < 0 || id >= games.Count)
            {
                return NotFound();
            }

            games.RemoveAt(id);
            return NoContent();
        }
    }
}