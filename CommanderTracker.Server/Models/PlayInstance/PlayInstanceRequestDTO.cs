namespace CommanderTracker.Models;

public class PlayInstanceCreateRequestDTO
{
    public int TurnOrder { get; set; }
    public int EndPosition { get; set; }
    public string Notes { get; set; } = string.Empty;
    public required Guid DeckId { get; set; }
    public required Guid PilotId { get; set; }
}
