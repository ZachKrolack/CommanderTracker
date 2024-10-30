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
