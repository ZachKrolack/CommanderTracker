using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CommanderTracker.Data;
using Microsoft.AspNetCore.Identity;
using CommanderTracker.DTOs;
using CommanderTracker.Extensions;
using Microsoft.AspNetCore.Authorization;
using CommanderTracker.Models;

namespace CommanderTracker.Controllers;

[Route("api/play-groups/{playGroupId}/games")]
[ApiController]
public class PlayGroupGamesController(DataContext context, UserManager<AppUser> userManager) : ControllerBase
{
    private readonly DataContext _context = context;
    private readonly UserManager<AppUser> _userManager = userManager;

    // GET: api/PlayGroups/5/Games
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GameResponseDTO>>> GetPlayGroupGames(Guid playGroupId)
    {
        return await _context.Games
            .Where(game => game.PlayGroupId == playGroupId)
                .OrderByDescending(game => game.CreatedDate)
                .ThenBy(game => game.Id)
            .Include(game => game.PlayInstances.OrderBy(playInstance => playInstance.EndPosition))
            .Include(game => game.PlayInstances)
                .ThenInclude(playInstance => playInstance.PlayGroupDeck)
                    .ThenInclude(pgd => pgd.Deck)
            .Include(game => game.PlayInstances)
                .ThenInclude(playInstance => playInstance.Pilot)
            .Include(game => game.PlayGroup)
            .Select(game => GameDTOMapper.ToGameResponseDTO(game))
            .ToListAsync();
    }

    // POST: api/PlayGroups/5/Games
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<GameBaseResponseDTO>> PostPlayGroupGame(Guid playGroupId, GameCreateRequestDTO request)
    {
        var userId = User.GetId();
        var appUser = await _userManager.FindByIdAsync(userId);

        if (appUser == null)
        {
            return Unauthorized();
        }

        var game = GameDTOMapper.ToGame(request, playGroupId, appUser.Id);

        _context.Games.Add(game);

        foreach (var playInstanceCreateRequest in request.PlayInstances)
        {
            var playInstance = PlayInstanceDTOMapper
                .ToPlayInstance(playInstanceCreateRequest, game.Id, appUser.Id);

            _context.PlayInstances.Add(playInstance);
        }

        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(PostPlayGroupGame),
            new { id = game.Id },
            GameDTOMapper.ToGameBaseResponseDTO(game));
    }
}
