using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CommanderTracker.Data;
using Microsoft.AspNetCore.Identity;
using CommanderTracker.DTOs;
using CommanderTracker.Extensions;
using Microsoft.AspNetCore.Authorization;
using CommanderTracker.Models;

namespace CommanderTracker.Controllers;

[Route("api/play-groups/{playGroupId}/decks")]
[ApiController]
public class PlayGroupDecksController(DataContext context, UserManager<AppUser> userManager) : ControllerBase
{
    private readonly DataContext _context = context;
    private readonly UserManager<AppUser> _userManager = userManager;

    // GET: api/PlayGroups/5/Decks
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PlayGroupDeckBaseResponseDTO>>> GetPlayGroupDecks(Guid playGroupId)
    {
        return await _context.PlayGroupDecks
            .Where(pgd => pgd.PlayGroupId == playGroupId)
            .Include(pgd => pgd.Deck)
            .Include(pgd => pgd.PlayGroup)
            // .Include(pgd => pgd.Pilot)
            .Select(pgd => PlayGroupDeckDTOMapper.ToPlayGroupDeckBaseResponseDTO(pgd))
            .ToListAsync();
    }

    // GET: api/PlayGroups/5/Decks/5
    [HttpGet("{deckId}")]
    public async Task<ActionResult<PlayGroupDeckResponseDTO>> GetPlayGroupDeck(Guid playGroupId, Guid deckId)
    {
        var deck = await _context.PlayGroupDecks
            .Where(pgd => pgd.PlayGroupId == playGroupId && pgd.DeckId == deckId)
            .Include(pgd => pgd.Deck)
            .Include(pgd => pgd.PlayGroup)
            // .Include(pgd => pgd.Pilot)         
            .Include(pgd => pgd.PlayInstances
                .OrderByDescending(playInstance => playInstance.CreatedDate)
                .ThenBy(playInstance => playInstance.Id))
            .Include(pgd => pgd.PlayInstances)
                .ThenInclude(pi => pi.Pilot)
            .Include(pgd => pgd.PlayInstances)
                .ThenInclude(pi => pi.Game)
                    .ThenInclude(game => game.PlayInstances)
                        .ThenInclude(pi => pi.PlayGroupDeck)
                            .ThenInclude(pgd => pgd.Deck)
            .Include(pgd => pgd.PlayInstances)
                .ThenInclude(pi => pi.Game)
                    .ThenInclude(game => game.PlayInstances)
                        .ThenInclude(pi => pi.Pilot)
            .Include(pgd => pgd.PlayInstances)
                .ThenInclude(pi => pi.Game)
                    .ThenInclude(game => game.PlayGroup)
            .FirstOrDefaultAsync();

        if (deck == null)
        {
            return NotFound();
        }

        return PlayGroupDeckDTOMapper.ToPlayGroupDeckResponseDTO(deck);
    }

    // POST: api/PlayGroups/5/Decks
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<DeckBaseResponseDTO>> PostPlayGroupDeck(Guid playGroupId, DeckCreateRequestDTO request)
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
            // PilotId = null // TODO
        };

        var playGroupDeck = PlayGroupDeckDTOMapper.ToPlayGroupDeck(playGroupDeckRequest, playGroupId, appUser.Id);

        _context.PlayGroupDecks.Add(playGroupDeck);

        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(PostPlayGroupDeck),
            new { id = deck.Id },
            DeckDTOMapper.ToDeckBaseResponseDTO(deck));
    }
}
