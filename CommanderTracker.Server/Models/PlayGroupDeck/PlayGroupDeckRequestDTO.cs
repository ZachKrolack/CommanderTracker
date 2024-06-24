namespace CommanderTracker.Models.DTO;

public class PlayGroupDeckCreateRequestDTO
{
    public Guid DeckId { get; set; }
    public Guid? PilotId { get; set; } = null;
}
