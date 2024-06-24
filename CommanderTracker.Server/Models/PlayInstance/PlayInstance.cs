using System.ComponentModel.DataAnnotations.Schema;

namespace CommanderTracker.Models;

[Table("play_instances")]
public class PlayInstance : BaseEntity
{
    [Column("turn_order")]
    public int TurnOrder { get; set; }

    [Column("end_position")]
    public int EndPosition { get; set; }

    [Column("notes")]
    public string Notes { get; set; } = string.Empty;

    [Column("deck_id")]
    public Guid DeckId { get; set; }
    public Deck Deck { get; set; } = null!;

    [Column("pilot_id")]
    public Guid PilotId { get; set; }
    public Pilot Pilot { get; set; } = null!;

    [Column("game_id")]
    public Guid GameId { get; set; }
    public Game Game { get; set; } = null!;
}
