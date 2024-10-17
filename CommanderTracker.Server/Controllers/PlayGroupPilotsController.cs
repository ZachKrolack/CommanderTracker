using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CommanderTracker.Data;
using Microsoft.AspNetCore.Identity;
using CommanderTracker.DTOs;
using CommanderTracker.Extensions;
using Microsoft.AspNetCore.Authorization;
using CommanderTracker.Models;

namespace CommanderTracker.Controllers;

[Route("api/play-groups/{playGroupId}/pilots")]
[ApiController]
public class PlayGroupPilotsController(DataContext context, UserManager<AppUser> userManager) : ControllerBase
{
    private readonly DataContext _context = context;
    private readonly UserManager<AppUser> _userManager = userManager;

    // GET: api/PlayGroups/5/Pilots
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PilotBaseResponseDTO>>> GetPlayGroupPilots(Guid playGroupId)
    {
        return await _context.Pilots
            .Where(pilot => pilot.PlayGroupId == playGroupId)
            .Select(pilot => PilotDTOMapper.ToPilotBaseResponseDTO(pilot))
            .ToListAsync();
    }

    // GET: api/PlayGroups/5/Pilots/5
    [HttpGet("{pilotId}")]
    public async Task<ActionResult<PilotResponseDTO>> GetPlayGroupPilot(Guid playGroupId, Guid pilotId)
    {
        var pilot = await _context.Pilots
            .Where(pilot => pilot.PlayGroupId == playGroupId && pilot.Id == pilotId)
            .Include(pilot => pilot.PlayInstances
                .OrderByDescending(playInstance => playInstance.CreatedDate)
                .ThenBy(playInstance => playInstance.Id))
            /*
            .Include(pilot => pilot.PlayInstances)
                .ThenInclude(pi => pi.Game)
                    .ThenInclude(game => game.PlayInstances)
                        .ThenInclude(pi => pi.PlayGroupDeck)
                            .ThenInclude(pgd => pgd.Deck)
            .Include(pilot => pilot.PlayInstances)
                .ThenInclude(pi => pi.Game)
                    .ThenInclude(game => game.PlayInstances)
                        .ThenInclude(pi => pi.Pilot)
            */
            .Include(deck => deck.PlayInstances)
                .ThenInclude(pi => pi.Game)
                    .ThenInclude(game => game.PlayInstances)
                        .ThenInclude(pi => pi.PlayGroupDeck)
                            .ThenInclude(pgd => pgd.Deck)
            .Include(deck => deck.PlayInstances)
                .ThenInclude(pi => pi.Game)
                    .ThenInclude(game => game.PlayInstances)
                        .ThenInclude(pi => pi.Pilot)
            .Include(deck => deck.PlayInstances)
                .ThenInclude(pi => pi.Game)
                    .ThenInclude(game => game.PlayGroup)
            .Include(pilot => pilot.PlayInstances)
                .ThenInclude(pi => pi.PlayGroupDeck)
                    .ThenInclude(pgd => pgd.Deck)
            .FirstOrDefaultAsync();

        if (pilot == null)
        {
            return NotFound();
        }

        return PilotDTOMapper.ToPilotResponseDTO(pilot);
    }

    // POST: api/PlayGroups/5/Pilots
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<PilotBaseResponseDTO>> PostPlayGroupPilot(Guid playGroupId, PilotCreateRequestDTO request)
    {
        var userId = User.GetId();
        var appUser = await _userManager.FindByIdAsync(userId);

        if (appUser == null)
        {
            return Unauthorized();
        }

        var pilot = PilotDTOMapper.ToPilot(request, playGroupId, appUser.Id);

        _context.Pilots.Add(pilot);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(PostPlayGroupPilot),
            new { id = pilot.Id },
            PilotDTOMapper.ToPilotBaseResponseDTO(pilot));
    }
}
