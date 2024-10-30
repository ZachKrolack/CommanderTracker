using CommanderTracker.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommanderTracker.Models;

[Table("decks")]
public class Deck : BaseEntity
{
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("color_identity")]
    public ColorIdentity ColorIdentity { get; set; }

    public List<PlayGroupDeck> PlayGroupDecks { get; set; } = [];
}
