namespace CommanderTracker.Models.DTO;

public class PilotCreateRequestDTO
{
    public required string Name { get; set; } = string.Empty;
    public string? AppUserId { get; set; } = null;
}

public class PilotUpdateRequestDTO
{
    public required Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? AppUserId { get; set; } = null;
}
