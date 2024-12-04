using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CommanderTracker.Data;
using CommanderTracker.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using CommanderTracker.Extensions;
using CommanderTracker.Models;

namespace CommanderTracker.Controllers
{
    [Route("api")]
    [ApiController]
    public class DecksController(DataContext context, UserManager<AppUser> userManager) : ControllerBase
    {
        private readonly DataContext _context = context;
        private readonly UserManager<AppUser> _userManager = userManager;

        // GET: api/Decks
        [HttpGet("decks")]
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
                .OrderByDescending(deck => deck.UpdatedDate)
                    .ThenBy(deck => deck.Id)
                .Select(deck => DeckDTOMapper.ToDeckBaseResponseDTO(deck))
                .ToListAsync();
        }

        // GET: api/PlayGroups/5/Decks
        [HttpGet("play-groups/{playGroupId}/decks")]
        public async Task<ActionResult<IEnumerable<PlayGroupDeckBaseResponseDTO>>> GetPlayGroupDecks(Guid playGroupId)
        {
            return await _context.PlayGroupDecks
                .Where(pgd => pgd.PlayGroupId == playGroupId)
                .Include(pgd => pgd.Deck)
                .OrderByDescending(pgd => pgd.Deck.UpdatedDate)
                    .ThenBy(pgd => pgd.Deck.Id)
                .Select(pgd => PlayGroupDeckDTOMapper.ToPlayGroupDeckBaseResponseDTO(pgd))
                .ToListAsync();
        }

        // GET: api/Decks/5
        [HttpGet("decks/{deckId}")]
        [Authorize]
        public async Task<ActionResult<DeckResponseDTO>> GetDeck(Guid deckId)
        {
            var userId = User.GetId();
            var appUser = await _userManager.FindByIdAsync(userId);

            if (appUser == null) { return Unauthorized(); }

            var deck = await _context.Decks
                .Where(deck => deck.Id == deckId)
                .Include(deck => deck.PlayInstances
                    .OrderByDescending(pi => pi.CreatedDate)
                        .ThenBy(pi => pi.Id))
                    .ThenInclude(pi => pi.Game)
                        .ThenInclude(game => game.PlayInstances)
                            .ThenInclude(pgd => pgd.Deck)
                .Include(deck => deck.PlayInstances)
                    .ThenInclude(pi => pi.Game)
                        .ThenInclude(game => game.PlayInstances)
                            .ThenInclude(pi => pi.Pilot)
                .Include(deck => deck.PlayInstances)
                    .ThenInclude(pi => pi.Game)
                        .ThenInclude(game => game.PlayGroup)
                .Include(deck => deck.PlayGroups)
                .FirstOrDefaultAsync();

            if (deck == null) { return NotFound(); }
            if (appUser.Id != deck.CreatedById) { return NotFound(); }

            var avgEndPosition = await _context.PlayInstances
                .Where(pi => pi.DeckId == deckId)
                .Select(pi => pi.EndPosition)
                .AverageAsync();

            return DeckDTOMapper.ToDeckResponseDTO(deck);
        }

        // GET: api/PlayGroups/5/Decks/5
        [HttpGet("play-groups/{playGroupId}/decks/{deckId}")]
        public async Task<ActionResult<PlayGroupDeckResponseDTO>> GetPlayGroupDeck(Guid playGroupId, Guid deckId)
        {
            var deck = await _context.PlayGroupDecks
                .Where(pgd => pgd.PlayGroupId == playGroupId && pgd.DeckId == deckId)
                .Include(pgd => pgd.Deck)       
                .Include(pgd => pgd.PlayInstances
                    .OrderByDescending(playInstance => playInstance.CreatedDate)
                        .ThenBy(playInstance => playInstance.Id))
                    .ThenInclude(pi => pi.Game)
                        .ThenInclude(game => game.PlayInstances)
                            .ThenInclude(pgd => pgd.Deck)       
                .Include(pgd => pgd.PlayInstances)
                    .ThenInclude(pi => pi.Game)
                        .ThenInclude(game => game.PlayInstances)
                            .ThenInclude(pi => pi.Pilot)
                .Include(pgd => pgd.PlayInstances)
                    .ThenInclude(pi => pi.Game)
                        .ThenInclude(game => game.PlayGroup)
                .Include(pgd => pgd.PlayInstances)
                    .ThenInclude(pi => pi.Pilot)
                .FirstOrDefaultAsync();

            if (deck == null) { return NotFound(); }

            var avgEndPosition = await _context.PlayInstances
                .Where(pgd => pgd.PlayGroupId == playGroupId && pgd.DeckId == deckId)
                .Select(pi => pi.EndPosition)
                .AverageAsync();

            return PlayGroupDeckDTOMapper.ToPlayGroupDeckResponseDTO(deck);
        }

        // PUT: api/Decks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("decks/{deckId}")]
        [Authorize]
        public async Task<IActionResult> PutDeck(Guid deckId, DeckUpdateRequestDTO request)
        {
            if (deckId != request.Id) { return BadRequest(); }

            var userId = User.GetId();
            var appUser = await _userManager.FindByIdAsync(userId);

            if (appUser == null) { return Unauthorized(); }

            var deck = await _context.Decks.FindAsync(deckId);

            if (deck == null) { return NotFound(); }
            if (appUser.Id != deck.CreatedById) { return NotFound(); }

            _context.Entry(deck).State = EntityState.Modified;

            deck.Name = request.Name;
            deck.ColorIdentity = request.ColorIdentity;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeckExists(deckId))
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
        [HttpPost("decks")]
        [Authorize]
        public async Task<ActionResult<DeckBaseResponseDTO>> PostDeck(DeckCreateRequestDTO request)
        {
            var userId = User.GetId();
            var appUser = await _userManager.FindByIdAsync(userId);

            if (appUser == null) { return Unauthorized(); }

            var deck = DeckDTOMapper.ToDeck(request, appUser.Id);

            _context.Decks.Add(deck);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(PostDeck),
                new { id = deck.Id },
                DeckDTOMapper.ToDeckBaseResponseDTO(deck));
        }

        // POST: api/PlayGroups/5/Decks
        [HttpPost("play-groups/{playGroupId}/decks")]
        [Authorize]
        public async Task<ActionResult<DeckBaseResponseDTO>> PostPlayGroupDeck(Guid playGroupId, DeckCreateRequestDTO request)
        {
            var userId = User.GetId();
            var appUser = await _userManager.FindByIdAsync(userId);

            if (appUser == null) { return Unauthorized(); }

            var playGroup = await _context.PlayGroups.FindAsync(playGroupId);

            if (playGroup == null) { return NotFound(); }
            if (appUser.Id != playGroup.CreatedById) { return NotFound(); }

            var deck = DeckDTOMapper.ToDeck(request, appUser.Id);

            _context.Decks.Add(deck);

            var playGroupDeckRequest = new PlayGroupDeckCreateRequestDTO
            {
                DeckId = deck.Id
            };

            var playGroupDeck = PlayGroupDeckDTOMapper.ToPlayGroupDeck(playGroupDeckRequest, playGroupId, appUser.Id);

            _context.PlayGroupDecks.Add(playGroupDeck);

            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(PostPlayGroupDeck),
                new { id = deck.Id },
                DeckDTOMapper.ToDeckBaseResponseDTO(deck));
        }

        // POST: api/PlayGroups/5/Decks
        [HttpPost("play-groups/{playGroupId}/decks/{deckId}")]
        [Authorize]
        public async Task<ActionResult<DeckBaseResponseDTO>> PostPlayGroupDeck(Guid playGroupId, Guid deckId)
        {
            var userId = User.GetId();
            var appUser = await _userManager.FindByIdAsync(userId);

            if (appUser == null) { return Unauthorized(); }

            var playGroup = await _context.PlayGroups.FindAsync(playGroupId);

            if (playGroup == null) { return NotFound(); }
            if (appUser.Id != playGroup.CreatedById) { return NotFound(); }

            var deck = await _context.Decks.FindAsync(deckId);

            if (deck == null) { return NotFound(); }
            if (appUser.Id != deck.CreatedById) { return NotFound(); }

            var playGroupDeckRequest = new PlayGroupDeckCreateRequestDTO
            {
                DeckId = deckId
            };

            var playGroupDeck = PlayGroupDeckDTOMapper.ToPlayGroupDeck(playGroupDeckRequest, playGroupId, appUser.Id);

            _context.PlayGroupDecks.Add(playGroupDeck);

            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(PostPlayGroupDeck),
                new { id = deck.Id },
                DeckDTOMapper.ToDeckBaseResponseDTO(deck));
        }

        // DELETE: api/Decks/5
        [HttpDelete("decks/{deckId}")]
        [Authorize]
        public async Task<IActionResult> DeleteDeck(Guid deckId)
        {
            var userId = User.GetId();
            var appUser = await _userManager.FindByIdAsync(userId);

            if (appUser == null) { return Unauthorized(); }

            var deck = await _context.Decks.FindAsync(deckId);

            if (deck == null) { return NotFound(); }
            if (appUser.Id != deck.CreatedById) { return NotFound(); }

            _context.Decks.Remove(deck);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/PlayGroups/5/Decks/5
        [HttpDelete("play-groups/{playGroupId}/decks/{deckId}")]
        [Authorize]
        public async Task<IActionResult> DeletePlayGroupDeck(Guid playGroupId, Guid deckId)
        {
            var userId = User.GetId();
            var appUser = await _userManager.FindByIdAsync(userId);

            if (appUser == null) { return Unauthorized(); }

            // TODO: Deck Authorization?

            var playGroupDeck = await _context.PlayGroupDecks
                .Where(pgd => pgd.PlayGroupId == playGroupId && pgd.DeckId == deckId)
                .FirstOrDefaultAsync();

            if (playGroupDeck == null) { return NotFound(); }

            _context.PlayGroupDecks.Remove(playGroupDeck);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeckExists(Guid id)
        {
            return _context.Decks.Any(e => e.Id == id);
        }
    }
}
