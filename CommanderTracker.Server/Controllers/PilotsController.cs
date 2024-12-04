using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CommanderTracker.Data;
using CommanderTracker.DTOs;
using CommanderTracker.Models;
using Microsoft.AspNetCore.Identity;
using CommanderTracker.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace CommanderTracker.Controllers;

[Route("api")]
[ApiController]
public class PilotsController(DataContext context, UserManager<AppUser> userManager) : ControllerBase
{
    private readonly DataContext _context = context;
    private readonly UserManager<AppUser> _userManager = userManager;

    // GET: api/Pilots/5
    [HttpGet("pilots/{pilotId}")]
    public async Task<ActionResult<PilotResponseDTO>> GetPilot(Guid pilotId)
    {
        var pilot = await _context.Pilots
            .Where(pilot => pilot.Id == pilotId)
            .Include(pilot => pilot.PlayInstances
                .OrderByDescending(playInstance => playInstance.CreatedDate)
                    .ThenBy(playInstance => playInstance.Id))
            .Include(pilot => pilot.PlayInstances)
                .ThenInclude(pi => pi.Game)
                    .ThenInclude(game => game.PlayInstances)
                        .ThenInclude(pgd => pgd.Deck)
            .Include(pilot => pilot.PlayInstances)
                .ThenInclude(pi => pi.Game)
                    .ThenInclude(game => game.PlayInstances)
                        .ThenInclude(pgd => pgd.PlayGroup)
            .Include(pilot => pilot.PlayInstances)
                .ThenInclude(pi => pi.Game)
                    .ThenInclude(game => game.PlayInstances)
                        .ThenInclude(pi => pi.Pilot)
            .Include(pilot => pilot.PlayInstances)
                .ThenInclude(pi => pi.PlayGroupDeck)
            .FirstOrDefaultAsync();

        if (pilot == null) { return NotFound(); }

        var avgEndPosition = await _context.PlayInstances
            .Where(pi => pi.PilotId == pilotId)
            .Select(pi => pi.EndPosition)
            .AverageAsync();

        return PilotDTOMapper.ToPilotResponseDTO(pilot);
    }

    // GET: api/PlayGroups/5/Pilots
    [HttpGet("play-groups/{playGroupId}/pilots")]
    public async Task<ActionResult<IEnumerable<PilotBaseResponseDTO>>> GetPilots(Guid playGroupId)
    {
        return await _context.Pilots
            .Where(pilot => pilot.PlayGroupId == playGroupId)
            .Select(pilot => PilotDTOMapper.ToPilotBaseResponseDTO(pilot))
            .ToListAsync();
    }

    // PUT: api/Pilots/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("play-groups/{playGroupId}/pilots/{pilotId}")]
    [Authorize]
    public async Task<IActionResult> PutPilot(Guid playGroupId, Guid pilotId, PilotUpdateRequestDTO request)
    {
        if (pilotId != request.Id) { return BadRequest(); }

        var userId = User.GetId();
        var appUser = await _userManager.FindByIdAsync(userId);

        if (appUser == null) { return Unauthorized(); }

        var playGroup = await _context.PlayGroups.FindAsync(playGroupId);

        if (playGroup == null) { return NotFound(); }
        if (playGroup.CreatedById != userId) { return NotFound(); }

        var pilot = await _context.Pilots.FindAsync(pilotId);

        if (pilot == null) { return NotFound(); }

        _context.Entry(pilot).State = EntityState.Modified;

        pilot.Name = request.Name;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PilotExists(pilotId))
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

    // POST: api/PlayGroups/5/Pilots
    [HttpPost("play-groups/{playGroupId}/pilots")]
    [Authorize]
    public async Task<ActionResult<PilotBaseResponseDTO>> PostPilot(Guid playGroupId, PilotCreateRequestDTO request)
    {
        var userId = User.GetId();
        var appUser = await _userManager.FindByIdAsync(userId);

        if (appUser == null) { return Unauthorized(); }

        var playGroup = await _context.PlayGroups.FindAsync(playGroupId);

        if (playGroup == null) { return NotFound(); }
        if (playGroup.CreatedById != userId) { return NotFound(); }

        var pilot = PilotDTOMapper.ToPilot(request, playGroupId, appUser.Id);

        _context.Pilots.Add(pilot);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(PostPilot),
            new { id = pilot.Id },
            PilotDTOMapper.ToPilotBaseResponseDTO(pilot));
    }

    // DELETE: api/Pilots/5
    [HttpDelete("play-groups/{playGroupId}/pilots/{pilotId}")]
    [Authorize]
    public async Task<IActionResult> DeletePilot(Guid playGroupId, Guid pilotId)
    {
        var userId = User.GetId();
        var appUser = await _userManager.FindByIdAsync(userId);

        if (appUser == null) { return Unauthorized(); }

        var playGroup = await _context.PlayGroups.FindAsync(playGroupId);

        if (playGroup == null) { return NotFound(); }
        if (playGroup.CreatedById != userId) { return NotFound(); }

        var pilot = await _context.Pilots.FindAsync(pilotId);

        if (pilot == null) { return NotFound(); }

        _context.Pilots.Remove(pilot);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PilotExists(Guid id)
    {
        return _context.Pilots.Any(e => e.Id == id);
    }
}
