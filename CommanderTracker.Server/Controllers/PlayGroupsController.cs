using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CommanderTracker.Data;
using CommanderTracker.Models;
using Microsoft.AspNetCore.Identity;
using CommanderTracker.Server.Extensions;
using CommanderTracker.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using CommanderTracker.Model.DTO;

namespace CommanderTracker.Server.Controllers
{
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

        // GET: api/PlayGroups/5/Decks
        [HttpGet("{id}/decks")]
        public async Task<ActionResult<IEnumerable<PlayGroupDeckBaseResponseDTO>>> GetPlayGroupDecks(Guid id)
        {
            return await _context.PlayGroupDecks
                .Where(pgd => pgd.PlayGroupId == id)
                .Include(pgd => pgd.Deck)
                .Include(pgd => pgd.Pilot)
                .Select(pgd => PlayGroupDeckDTOMapper.ToPlayGroupDeckBaseResponseDTO(pgd))
                .ToListAsync();
        }

        // GET: api/PlayGroups/5/Decks/5
        [HttpGet("{id}/decks/{deckId}")]
        public async Task<ActionResult<PlayGroupDeckResponseDTO>> GetPlayGroupDeck(Guid id, Guid deckId)
        {
            var deck = await _context.PlayGroupDecks
                .Where(pgd => pgd.PlayGroupId == id && pgd.Id == deckId)
                .Include(pgd => pgd.Deck)
                .Include(pgd => pgd.Pilot)
                .Include(deck => deck.PlayInstances)
                .FirstOrDefaultAsync();

            if (deck == null)
            {
                return NotFound();
            }

            return PlayGroupDeckDTOMapper.ToPlayGroupDeckResponseDTO(deck);   
        }

        // POST: api/PlayGroups/5/Decks
        [HttpPost("{id}/decks")]
        [Authorize]
        public async Task<ActionResult<PilotBaseResponseDTO>> PostPlayGroupDeck(Guid id, DeckCreateRequestDTO request)
        {
            var userId = User.GetId();
            var appUser = await _userManager.FindByIdAsync(userId);

            if (appUser == null)
            {
                return Unauthorized();
            }

            var deck = DeckDTOMapper.ToDeck(request, appUser.Id);

            _context.Decks.Add(deck);

            var playGroupDeckRequest = new PlayGroupDeckCreateRequestDTO
            {
                DeckId = deck.Id,
                PilotId = null // TODO
            };

            var playGroupDeck = PlayGroupDeckDTOMapper.ToPlayGroupDeck(playGroupDeckRequest, id, appUser.Id);

            _context.PlayGroupDecks.Add(playGroupDeck);

            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(PostPlayGroupPilot),
                new { id = deck.Id },
                DeckDTOMapper.ToDeckBaseResponseDTO(deck));
        }

        // GET: api/PlayGroups/5/Pilots
        [HttpGet("{id}/pilots")]
        public async Task<ActionResult<IEnumerable<PilotBaseResponseDTO>>> GetPlayGroupPilots(Guid id)
        {
            return await _context.Pilots
                .Where(pilot => pilot.PlayGroupId == id)
                .Select(pilot => PilotDTOMapper.ToPilotBaseResponseDTO(pilot))
                .ToListAsync();
        }

        // GET: api/PlayGroups/5/Pilots/5
        [HttpGet("{id}/pilots/{pilotId}")]
        public async Task<ActionResult<PilotResponseDTO>> GetPlayGroupPilot(Guid id, Guid pilotId)
        {
            var pilot = await _context.Pilots
                .Where(pilot=> pilot.PlayGroupId == id && pilot.Id == pilotId)
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

        // POST: api/PlayGroups/5/Pilots
        [HttpPost("{id}/pilots")]
        [Authorize]
        public async Task<ActionResult<PilotBaseResponseDTO>> PostPlayGroupPilot(Guid id, PilotCreateRequestDTO request)
        {
            var userId = User.GetId();
            var appUser = await _userManager.FindByIdAsync(userId);

            if (appUser == null)
            {
                return Unauthorized();
            }

            var pilot = PilotDTOMapper.ToPilot(request, id, appUser.Id);

            _context.Pilots.Add(pilot);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(PostPlayGroupPilot),
                new { id = pilot.Id },
                PilotDTOMapper.ToPilotBaseResponseDTO(pilot));
        }

        // GET: api/PlayGroups/5/Games
        [HttpGet("{id}/games")]
        public async Task<ActionResult<IEnumerable<GameBaseResponseDTO>>> GetPlayGroupGames(Guid id)
        {
            return await _context.Games
                .Where(game => game.PlayGroupId == id)
                .Select(game => GameDTOMapper.ToGameBaseResponseDTO(game))
                .ToListAsync();
        }

        // GET: api/PlayGroups/5/Games/5
        [HttpGet("{id}/games/{gameId}")]
        public async Task<ActionResult<GameResponseDTO>> GetPlayGroupGame(Guid id, Guid gameId)
        {
            var game = await _context.Games
                .Where(game => game.PlayGroupId == id && game.Id == gameId)
                .Include(game => game.CreatedBy)
                .Include(game => game.PlayInstances.OrderBy(playInstance => playInstance.EndPosition))
                .Include(game => game.PlayInstances)
                    .ThenInclude(playInstance => playInstance.Pilot)
                .Include(game => game.PlayInstances)
                    .ThenInclude(playInstance => playInstance.Deck)
                .FirstOrDefaultAsync();

            if (game == null)
            {
                return NotFound();
            }

            return GameDTOMapper.ToGameResponseDTO(game);
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
}
