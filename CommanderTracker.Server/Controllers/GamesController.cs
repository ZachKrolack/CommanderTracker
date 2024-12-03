using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CommanderTracker.Data;
using CommanderTracker.DTOs;
using Microsoft.AspNetCore.Identity;
using CommanderTracker.Extensions;
using Microsoft.AspNetCore.Authorization;
using CommanderTracker.Models;

namespace CommanderTracker.Controllers;

[Route("api")]
[ApiController]
public class GamesController(DataContext context, UserManager<AppUser> userManager) : ControllerBase
{
    private readonly DataContext _context = context;
    private readonly UserManager<AppUser> _userManager = userManager;

    // GET: api/Games
    [HttpGet("games")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<GameResponseDTO>>> GetGames()
    {
        var userId = User.GetId();
        var appUser = await _userManager.FindByIdAsync(userId);

        if (appUser == null) { return Unauthorized(); }

        return await _context.Games
            .OrderByDescending(game => game.CreatedDate)
            .ThenBy(game => game.Id)
            .Include(game => game.PlayInstances.OrderBy(playInstance => playInstance.EndPosition))
            .Include(game => game.PlayInstances)
                .ThenInclude(playInstance => playInstance.Deck)
            .Include(game => game.PlayInstances)
                .ThenInclude(playInstance => playInstance.Pilot)
            .Include(game => game.PlayGroup)
            .Select(game => GameDTOMapper.ToGameResponseDTO(game))
            .ToListAsync();
    }

    // GET: api/PlayGroups/5/Games
    [HttpGet("play-groups/{playGroupId}/games")]
    public async Task<ActionResult<IEnumerable<GameResponseDTO>>> GetGames(Guid playGroupId)
    {
        return await _context.Games
            .Where(game => game.PlayGroupId == playGroupId)
                .OrderByDescending(game => game.CreatedDate)
                .ThenBy(game => game.Id)
            .Include(game => game.PlayInstances.OrderBy(playInstance => playInstance.EndPosition))
            .Include(game => game.PlayInstances)
                .ThenInclude(playInstance => playInstance.Deck)
            .Include(game => game.PlayInstances)
                .ThenInclude(playInstance => playInstance.Pilot)
            .Include(game => game.PlayGroup)
            .Select(game => GameDTOMapper.ToGameResponseDTO(game))
            .ToListAsync();
    }

    // GET: api/Games/5
    [HttpGet("games/{gameId}")]
    public async Task<ActionResult<GameResponseDTO>> GetGame(Guid gameId)
    {
        var game = await _context.Games
            .Where(game => game.Id == gameId)
            .Include(game => game.CreatedBy)
            .Include(game => game.PlayInstances.OrderBy(playInstance => playInstance.EndPosition))
            .Include(game => game.PlayInstances)
                .ThenInclude(playInstance => playInstance.Pilot)
            .Include(game => game.PlayInstances)
                .ThenInclude(playInstance => playInstance.Deck)
            .Include(game => game.PlayGroup)
            .FirstOrDefaultAsync();

        if (game == null) { return NotFound(); }

        return GameDTOMapper.ToGameResponseDTO(game);
    }

    // PUT: api/Games/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("play-groups/{playGroupId}/games/{gameId}")]
    [Authorize]
    public async Task<IActionResult> PutGame(Guid playGroupId, Guid gameId, GameUpdateRequestDTO request)
    {
        if (gameId != request.Id) { return BadRequest(); }

        var userId = User.GetId();
        var appUser = await _userManager.FindByIdAsync(userId);

        if (appUser == null) { return Unauthorized(); }

        var playGroup = await _context.PlayGroups.FindAsync(playGroupId);

        if (playGroup == null) { return NotFound(); }
        if (playGroup.CreatedById != userId) { return NotFound(); }

        var game = await _context.Games.FindAsync(gameId);

        if (game == null) { return NotFound(); }

        _context.Entry(game).State = EntityState.Modified;

        game.Turns = request.Turns;
        game.Notes = request.Notes;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!GameExists(gameId))
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

    // POST: api/PlayGroups/5/Games
    [HttpPost("play-groups/{playGroupId}/games/")]
    [Authorize]
    public async Task<ActionResult<GameBaseResponseDTO>> PostPlayGroupGame(Guid playGroupId, GameCreateRequestDTO request)
    {
        var userId = User.GetId();
        var appUser = await _userManager.FindByIdAsync(userId);

        if (appUser == null) { return Unauthorized(); }

        var playGroup = await _context.PlayGroups.FindAsync(playGroupId);

        if (playGroup == null) { return NotFound(); }
        if (playGroup.CreatedById != userId) { return NotFound(); }

        var game = GameDTOMapper.ToGame(request, playGroupId, appUser.Id);

        _context.Games.Add(game);

        foreach (var playInstanceCreateRequest in request.PlayInstances)
        {
            var playInstance = PlayInstanceDTOMapper
                .ToPlayInstance(playInstanceCreateRequest, game.Id, playGroupId, appUser.Id);

            _context.PlayInstances.Add(playInstance);
        }

        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(PostPlayGroupGame),
            new { id = game.Id },
            GameDTOMapper.ToGameBaseResponseDTO(game));
    }

    // DELETE: api/Games/5
    [HttpDelete("play-groups/{playGroupId}/games/{gameId}")]
    [Authorize]
    public async Task<IActionResult> DeleteGame(Guid playGroupId, Guid gameId)
    {
        var userId = User.GetId();
        var appUser = await _userManager.FindByIdAsync(userId);

        if (appUser == null) { return Unauthorized(); }

        var playGroup = await _context.PlayGroups.FindAsync(playGroupId);

        if (playGroup == null) { return NotFound(); }
        if (playGroup.CreatedById != userId) { return NotFound(); }

        var game = await _context.Games.FindAsync(gameId);
        
        if (game == null) { return NotFound(); }

        _context.Games.Remove(game);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool GameExists(Guid id)
    {
        return _context.Games.Any(e => e.Id == id);
    }
}
