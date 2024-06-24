using System.ComponentModel.DataAnnotations.Schema;

namespace CommanderTracker.Models;

[Table("play_groups")]
public class PlayGroup : BaseEntity
{
    [Column("name")]
    public string Name {  get; set; } = string.Empty;
    public List<Pilot> Pilots { get; set; } = [];
    public List<Game> Games { get; set; } = [];
    public List<PlayGroupDeck> PlayGroupDecks { get; set; } = [];
}
