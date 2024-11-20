using CommanderTracker.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommanderTracker.Models;

[Table("pilots")]
public class Pilot : BaseEntity
{
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("role")]
    public PilotRole Role { get; set; } = PilotRole.Member;

    [Column("app_user_id")]
    public string? AppUserId { get; set; } = null;
    public AppUser? AppUser { get; set; } = null;

    [Column("play_group_id")]
    public Guid PlayGroupId { get; set; }
    public PlayGroup PlayGroup { get; set; } = null!;

    public List<PlayInstance> PlayInstances { get; set; } = [];
}
