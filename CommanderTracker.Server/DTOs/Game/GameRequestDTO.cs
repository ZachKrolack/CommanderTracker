namespace CommanderTracker.DTOs;

public class GameCreateRequestDTO
{
    public required List<PlayInstanceCreateRequestDTO> PlayInstances { get; set; } = [];
    public int Turns { get; set; }
    public string Notes { get; set; } = string.Empty;
}

public class GameUpdateRequestDTO
{
    public required Guid Id { get; set; }
    public int Turns { get; set; }
    public string Notes { get; set; } = string.Empty;
}
