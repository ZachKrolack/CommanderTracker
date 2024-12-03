using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CommanderTracker.Data;
using Microsoft.AspNetCore.Identity;
using CommanderTracker.DTOs;
using CommanderTracker.Extensions;
using Microsoft.AspNetCore.Authorization;
using CommanderTracker.Models;

namespace CommanderTracker.Controllers;

[Route("api")]
[ApiController]
public class PlayGroupsController(DataContext context, UserManager<AppUser> userManager) : ControllerBase
{
    private readonly DataContext _context = context;
    private readonly UserManager<AppUser> _userManager = userManager;

    // GET: api/PlayGroups
    [HttpGet("play-groups")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<PlayGroupBaseResponseDTO>>> GetPlayGroups()
    {
        var userId = User.GetId();
        var appUser = await _userManager.FindByIdAsync(userId);

        if (appUser == null) { return Unauthorized(); }

        return await _context.Pilots
            .Where(pilot => pilot.AppUserId == appUser.Id)
            .Include(pilot => pilot.PlayGroup)
            .Select(pilot => PlayGroupDTOMapper.ToPlayGroupBaseResponseDTO(pilot.PlayGroup))
            .ToListAsync();
    }

    // GET: api/PlayGroups/5
    [HttpGet("play-groups/{playGroupId}")]
    public async Task<ActionResult<PlayGroupResponseDTO>> GetPlayGroup(Guid playGroupId)
    {
        var playGroup = await _context.PlayGroups
            .Where(pg => pg.Id == playGroupId)
            .Include(pg => pg.CreatedBy)
            .Include(pg => pg.Games)
            .Include(pg => pg.Pilots)
            .Include(pg => pg.Decks)
            .FirstOrDefaultAsync();

        if (playGroup == null) { return NotFound(); }

        return PlayGroupDTOMapper.ToPlayGroupResponseDTO(playGroup);
    }

    // PUT: api/PlayGroups/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("play-groups/{playGroupId}")]
    [Authorize]
    public async Task<IActionResult> PutPlayGroup(Guid playGroupId, PlayGroupUpdateRequestDTO request)
    {
        if (playGroupId != request.Id) { return BadRequest(); }

        var userId = User.GetId();
        var appUser = await _userManager.FindByIdAsync(userId);

        if (appUser == null) { return Unauthorized(); }

        var playGroup = await _context.PlayGroups.FindAsync(playGroupId);

        if (playGroup == null) { return NotFound(); }
        if (playGroup.CreatedById != userId) { return NotFound(); }

        _context.Entry(playGroup).State = EntityState.Modified;

        playGroup.Name = request.Name;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PlayGroupExists(playGroupId))
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

    // POST: api/PlayGroups
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost("play-groups")]
    [Authorize]
    public async Task<ActionResult<PlayGroupBaseResponseDTO>> PostPlayGroup(PlayGroupCreateRequestDTO request)
    {
        var userId = User.GetId();
        var appUser = await _userManager.FindByIdAsync(userId);

        if (appUser == null) { return Unauthorized(); }

        var playGroup = PlayGroupDTOMapper.ToPlayGroup(request, appUser.Id);

        _context.PlayGroups.Add(playGroup);

        var pilotRequest = new PilotCreateRequestDTO
        {
            Name = appUser.UserName ?? appUser.Email ?? "", // TODO 
        };

        var pilot = PilotDTOMapper.ToPilot(pilotRequest, playGroup.Id, appUser.Id, true);

        _context.Pilots.Add(pilot);

        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(PostPlayGroup),
            new { id = playGroup.Id },
            PlayGroupDTOMapper.ToPlayGroupBaseResponseDTO(playGroup));
    }

    // DELETE: api/PlayGroups/5
    [HttpDelete("play-groups/{playGroupId}")]
    [Authorize]
    public async Task<IActionResult> DeletePlayGroup(Guid playGroupId)
    {
        var userId = User.GetId();
        var appUser = await _userManager.FindByIdAsync(userId);

        if (appUser == null) { return Unauthorized(); }

        var playGroup = await _context.PlayGroups.FindAsync(playGroupId);

        if (playGroup == null) { return NotFound(); }
        if (appUser.Id != playGroup.CreatedById) { return Unauthorized(); }

        _context.PlayGroups.Remove(playGroup);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PlayGroupExists(Guid id)
    {
        return _context.PlayGroups.Any(e => e.Id == id);
    }
}
