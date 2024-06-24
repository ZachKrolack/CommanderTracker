using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CommanderTracker.Data;
using CommanderTracker.Models;
using CommanderTracker.Models.DTO;
using Microsoft.AspNetCore.Identity;
using CommanderTracker.Server.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace CommanderTracker.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GamesController(DataContext context, UserManager<AppUser> userManager) : ControllerBase
    {
        private readonly DataContext _context = context;
        private readonly UserManager<AppUser> _userManager = userManager;

        // GET: api/Games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameResponseDTO>>> GetGames()
        {
            return await _context.Games
                .OrderByDescending(game => game.CreatedDate)
                .ThenBy(game => game.Id)
                .Include(game => game.PlayInstances.OrderBy(playInstance => playInstance.EndPosition))
                .Include(game => game.PlayInstances)
                    .ThenInclude(playInstance => playInstance.Deck)
                .Include(game => game.PlayInstances)
                    .ThenInclude(playInstance => playInstance.Pilot)
                .Select(game => GameDTOMapper.ToGameResponseDTO(game))
                .ToListAsync();
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameResponseDTO>> GetGame(Guid id)
        {
            var game = await _context.Games
                .Where(game => game.Id == id)
                .Include(game => game.CreatedBy)
                .Include(game => game.PlayInstances.OrderBy(playInstance => playInstance.EndPosition))
                .Include(game => game.PlayInstances)
                    .ThenInclude(playInstance => playInstance.Pilot)
                .Include(game => game.PlayInstances)
                    .ThenInclude(playInstance => playInstance.Deck)
                .FirstOrDefaultAsync();

            if (game == null)
            {
                return NotFound();
            }

            return GameDTOMapper.ToGameResponseDTO(game);
        }

        // PUT: api/Games/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGame(Guid id, GameUpdateRequestDTO request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            var game = await _context.Games.FindAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            _context.Entry(game).State = EntityState.Modified;

            game.Turns = request.Turns;
            game.Notes = request.Notes;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Games
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GameBaseResponseDTO>> PostGame(GameCreateRequestDTO request)
        {
            var userId = User.GetId();
            var appUser = await _userManager.FindByIdAsync(userId);

            if (appUser == null)
            {
                return Unauthorized();
            }

            var game = GameDTOMapper.ToGame(request, appUser.Id);

            _context.Games.Add(game);

            foreach(var playInstanceCreateRequest in request.PlayInstances)
            {
                var playInstance = PlayInstanceDTOMapper
                    .ToPlayInstance(playInstanceCreateRequest, game.Id, appUser.Id);

                _context.PlayInstances.Add(playInstance);
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostGame), new { id = game.Id }, GameDTOMapper.ToGameBaseResponseDTO(game));
        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(Guid id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GameExists(Guid id)
        {
            return _context.Games.Any(e => e.Id == id);
        }
    }
}
