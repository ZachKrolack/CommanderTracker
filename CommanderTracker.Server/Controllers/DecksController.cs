using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CommanderTracker.Data;
using CommanderTracker.Models;
using CommanderTracker.Models.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using CommanderTracker.Server.Extensions;

namespace CommanderTracker.Controllers
{
    [Route("api/decks")]
    [ApiController]
    public class DecksController(DataContext context, UserManager<AppUser> userManager) : ControllerBase
    {
        private readonly DataContext _context = context;   
        private readonly UserManager<AppUser> _userManager = userManager;

        // GET: api/Decks
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<DeckBaseResponseDTO>>> GetDecks()
        {
            var userId = User.GetId();
            var appUser = await _userManager.FindByIdAsync(userId);

            if (appUser == null)
            {
                return Unauthorized();
            }

            return await _context.Decks
                .Where(deck => deck.CreatedById == appUser.Id)
                .Select(deck => DeckDTOMapper.ToDeckBaseResponseDTO(deck))
                .ToListAsync();
        }

        // GET: api/Decks/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<DeckResponseDTO>> GetDeck(Guid id)
        {
            var deck = await _context.Decks
                .Where(deck => deck.Id == id)
                .Include(deck => deck.CreatedBy)
                .Include(deck => deck.PlayInstances
                    .OrderByDescending(playInstance => playInstance.CreatedDate)
                    .ThenBy(playInstance => playInstance.Id))
                .Include(deck => deck.PlayInstances)
                    .ThenInclude(pi => pi.Game)
                        .ThenInclude(game => game.PlayInstances)
                            .ThenInclude(pi => pi.Deck)
                        .ThenInclude(game => game.PlayInstances)
                            .ThenInclude(pi => pi.Pilot)
                .Include(deck => deck.PlayInstances)
                    .ThenInclude(pi => pi.Pilot)
                .FirstOrDefaultAsync();

            if (deck == null)
            {
                return NotFound();
            }

            return DeckDTOMapper.ToDeckResponseDTO(deck);
        }

        // PUT: api/Decks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutDeck(Guid id, DeckUpdateRequestDTO request)
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

            var deck = await _context.Decks.FindAsync(id);

            if (deck == null) 
            { 
                return NotFound(); 
            }

            if (appUser.Id != deck.CreatedById)
            {
                return Unauthorized();
            }

            _context.Entry(deck).State = EntityState.Modified;

            deck.Name = request.Name;
            deck.ColorIdentity = request.ColorIdentity;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeckExists(id))
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

        // POST: api/Decks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<DeckBaseResponseDTO>> PostDeck(DeckCreateRequestDTO request)
        {
            var userId = User.GetId();
            var appUser = await _userManager.FindByIdAsync(userId);

            if (appUser == null)
            {
                return Unauthorized();
            }

            var deck = DeckDTOMapper.ToDeck(request, appUser.Id);

            _context.Decks.Add(deck);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(PostDeck),
                new { id = deck.Id },
                DeckDTOMapper.ToDeckBaseResponseDTO(deck));
        }

        // DELETE: api/Decks/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteDeck(Guid id)
        {
            var userId = User.GetId();
            var appUser = await _userManager.FindByIdAsync(userId);

            if (appUser == null)
            {
                return Unauthorized();
            }

            var deck = await _context.Decks.FindAsync(id);

            if (deck == null)
            {
                return NotFound();
            }

            if (appUser.Id != deck.CreatedById)
            {
                return Unauthorized();
            }

            _context.Decks.Remove(deck);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeckExists(Guid id)
        {
            return _context.Decks.Any(e => e.Id == id);
        }
    }
}
