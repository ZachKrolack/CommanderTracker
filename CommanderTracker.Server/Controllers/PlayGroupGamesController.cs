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
    public async Task<ActionResult<IEnumerable<GameBaseResponseDTO>>> GetPlayGroupGames(Guid playGroupId)
    {
        return await _context.Games
            .Where(game => game.PlayGroupId == playGroupId)
            .Select(game => GameDTOMapper.ToGameBaseResponseDTO(game))
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
