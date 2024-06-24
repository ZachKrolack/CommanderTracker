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
    [Route("api/pilots")]
    [ApiController]
    public class PilotsController(DataContext context, UserManager<AppUser> userManager) : ControllerBase
    {
        private readonly DataContext _context = context;
        private readonly UserManager<AppUser> _userManager = userManager;

        // GET: api/Pilots
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PilotBaseResponseDTO>>> GetPilots()
        {
            return await _context.Pilots
                .Select(pilot => PilotDTOMapper.ToPilotBaseResponseDTO(pilot))
                .ToListAsync();
        }

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
                            .ThenInclude(pi => pi.Deck)
                        .ThenInclude(game => game.PlayInstances)
                            .ThenInclude(pi => pi.Pilot)
                .Include(pilot => pilot.PlayInstances)
                    .ThenInclude(pi => pi.Deck)
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

        /*
        // POST: api/Pilots
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<PilotBaseResponseDTO>> PostPilot(PilotCreateRequestDTO request)
        {
            var userId = User.GetId();
            var appUser = await _userManager.FindByIdAsync(userId);

            if (appUser == null)
            {
                return Unauthorized();
            }

            var pilot = PilotDTOMapper.ToPilot(request, appUser.Id);

            _context.Pilots.Add(pilot);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(PostPilot),
                new { id = pilot.Id },
                PilotDTOMapper.ToPilotBaseResponseDTO(pilot));
        }
        */

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
}
