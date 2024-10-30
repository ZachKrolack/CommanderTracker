using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CommanderTracker.Data;
using CommanderTracker.DTOs;

namespace CommanderTracker.Controllers;

[Route("api/pilots")]
[ApiController]
public class PilotsController(DataContext context) : ControllerBase
{
    private readonly DataContext _context = context;

    // GET: api/Pilots/5
    [HttpGet("{id}")]
    public async Task<ActionResult<PilotResponseDTO>> GetPilot(Guid id)
    {
        var pilot = await _context.Pilots
            .Where(pilot => pilot.Id == id)
            .Include(pilot => pilot.CreatedBy)
            .Include(pilot => pilot.PlayInstances
                .OrderByDescending(playInstance => playInstance.CreatedDate)
                .ThenBy(playInstance => playInstance.Id))
            .Include(pilot => pilot.PlayInstances)
                .ThenInclude(pi => pi.Game)
                    .ThenInclude(game => game.PlayInstances)
                        .ThenInclude(pi => pi.PlayGroupDeck)
                            .ThenInclude(pgd => pgd.Deck)
            .Include(pilot => pilot.PlayInstances)
                .ThenInclude(pi => pi.Game)
                    .ThenInclude(game => game.PlayInstances)
                        .ThenInclude(pi => pi.PlayGroupDeck)
                            .ThenInclude(pgd => pgd.PlayGroup)
            .Include(pilot => pilot.PlayInstances)
                .ThenInclude(pi => pi.Game)
                    .ThenInclude(game => game.PlayInstances)
                        .ThenInclude(pi => pi.Pilot)
            .Include(pilot => pilot.PlayInstances)
                .ThenInclude(pi => pi.PlayGroupDeck)
            .FirstOrDefaultAsync();

        if (pilot == null)
        {
            return NotFound();
        }

        return PilotDTOMapper.ToPilotResponseDTO(pilot);
    }

    // PUT: api/Pilots/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPilot(Guid id, PilotUpdateRequestDTO request)
    {
        if (id != request.Id)
        {
            return BadRequest();
        }

        var pilot = await _context.Pilots.FindAsync(id);

        if (pilot == null)
        {
            return NotFound();
        }

        _context.Entry(pilot).State = EntityState.Modified;

        pilot.Name = request.Name;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PilotExists(id))
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

    // DELETE: api/Pilots/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePilot(Guid id)
    {
        var pilot = await _context.Pilots.FindAsync(id);
        if (pilot == null)
        {
            return NotFound();
        }

        _context.Pilots.Remove(pilot);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PilotExists(Guid id)
    {
        return _context.Pilots.Any(e => e.Id == id);
    }
}
