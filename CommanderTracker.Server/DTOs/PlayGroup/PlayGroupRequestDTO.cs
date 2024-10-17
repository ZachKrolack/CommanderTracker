namespace CommanderTracker.DTOs;

public class PlayGroupCreateRequestDTO
{
    public required string Name { get; set; } = string.Empty;
    // public List<Guid> PilotIds { get; set; } = [];
}

public class PlayGroupUpdateRequestDTO
{
    public required Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
