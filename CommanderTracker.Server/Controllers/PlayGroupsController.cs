using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CommanderTracker.Data;
using Microsoft.AspNetCore.Identity;
using CommanderTracker.DTOs;
using CommanderTracker.Extensions;
using Microsoft.AspNetCore.Authorization;
using CommanderTracker.Models;

namespace CommanderTracker.Controllers;

[Route("api/play-groups")]
[ApiController]
public class PlayGroupsController(DataContext context, UserManager<AppUser> userManager) : ControllerBase
{
    private readonly DataContext _context = context;
    private readonly UserManager<AppUser> _userManager = userManager;

    // GET: api/PlayGroups
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<PlayGroupBaseResponseDTO>>> GetPlayGroups()
    {
        var userId = User.GetId();
        var appUser = await _userManager.FindByIdAsync(userId);

        if (appUser == null)
        {
            return Unauthorized();
        }

        return await _context.Pilots
            .Where(pilot => pilot.AppUserId == appUser.Id)
            .Include(pilot => pilot.PlayGroup)
            .Select(pilot => PlayGroupDTOMapper.ToPlayGroupBaseResponseDTO(pilot.PlayGroup))
            .ToListAsync();
    }

    // GET: api/PlayGroups/5
    [HttpGet("{id}")]
    public async Task<ActionResult<PlayGroupResponseDTO>> GetPlayGroup(Guid id)
    {
        var playGroup = await _context.PlayGroups
            .Where(pg => pg.Id == id)
            .Include(pg => pg.CreatedBy)
            .Include(pg => pg.Games)
            .Include(pg => pg.Pilots)
            .Include(pg => pg.PlayGroupDecks)
                .ThenInclude(pgd => pgd.Deck)
            .Include(pg => pg.PlayGroupDecks)
                .ThenInclude(pgd => pgd.Pilot)
            .FirstOrDefaultAsync();

        if (playGroup == null)
        {
            return NotFound();
        }

        return PlayGroupDTOMapper.ToPlayGroupResponseDTO(playGroup);
    }

    // PUT: api/PlayGroups/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> PutPlayGroup(Guid id, PlayGroupUpdateRequestDTO request)
    {
        var userId = User.GetId();
        var appUser = await _userManager.FindByIdAsync(userId);

        if (appUser == null)
        {
            return Unauthorized();
        }

        if (id != request.Id)
        {
            return BadRequest();
        }

        var playGroup = await _context.PlayGroups.FindAsync(id);

        if (playGroup == null)
        {
            return NotFound();
        }

        if (appUser.Id != playGroup.CreatedById)
        {
            return Unauthorized();
        }

        _context.Entry(playGroup).State = EntityState.Modified;

        playGroup.Name = request.Name;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PlayGroupExists(id))
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
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<PlayGroupBaseResponseDTO>> PostPlayGroup(PlayGroupCreateRequestDTO request)
    {
        var userId = User.GetId();
        var appUser = await _userManager.FindByIdAsync(userId);

        if (appUser == null)
        {
            return Unauthorized();
        }

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
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeletePlayGroup(Guid id)
    {
        var userId = User.GetId();
        var appUser = await _userManager.FindByIdAsync(userId);

        if (appUser == null)
        {
            return Unauthorized();
        }

        var playGroup = await _context.PlayGroups.FindAsync(id);

        if (playGroup == null)
        {
            return NotFound();
        }

        if (appUser.Id != playGroup.CreatedById)
        {
            return Unauthorized();
        }

        _context.PlayGroups.Remove(playGroup);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PlayGroupExists(Guid id)
    {
        return _context.PlayGroups.Any(e => e.Id == id);
    }
}
