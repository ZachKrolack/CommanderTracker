using System.ComponentModel.DataAnnotations.Schema;

namespace CommanderTracker.Models;

[Table("play_group_decks")]
public class PlayGroupDeck : BaseEntity
{
    [Column("deck_id")]
    public Guid DeckId { get; set; }
    public Deck Deck { get; set; } = null!;

    [Column("play_group_id")]
    public Guid PlayGroupId { get; set; }
    public PlayGroup PlayGroup { get; set; } = null!;

    public List<PlayInstance> PlayInstances { get; set; } = [];
}
