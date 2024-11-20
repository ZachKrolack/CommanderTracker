using Microsoft.AspNetCore.Identity;

namespace CommanderTracker.Models;

public class AppUser : IdentityUser {
    public List<Pilot> CreatedPilots { get; set; } = [];
    public List<Deck> Decks { get; set; } = [];
    public List<Game> Games { get; set; } = [];
    public List<Pilot> Pilots { get; set; } = [];
    public List<PlayGroup> PlayGroups { get; set; } = [];
    public List<PlayGroupDeck> PlayGroupDecks { get; set;} = [];
    public List<PlayInstance> PlayInstances { get; set; } = [];
}
