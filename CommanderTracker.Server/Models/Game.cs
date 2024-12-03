using System.ComponentModel.DataAnnotations.Schema;

namespace CommanderTracker.Models;

[Table("games")]
public class Game : BaseEntity
{
    [Column("turns")]
    public int Turns { get; set; }

    [Column("notes")]
    public string Notes { get; set; } = string.Empty;

    [Column("play_group_id")]
    public Guid PlayGroupId { get; set; }
    public PlayGroup PlayGroup { get; set; } = null!;

    public List<PlayInstance> PlayInstances { get; set; } = [];
}
