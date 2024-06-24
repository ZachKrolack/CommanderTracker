using CommanderTracker.Models.Enums;

namespace CommanderTracker.Models.DTO;

public class DeckCreateRequestDTO
{
    public required string Name { get; set; } = string.Empty;
    public required ColorIdentity ColorIdentity { get; set; }
}

public class DeckUpdateRequestDTO
{
    public required Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ColorIdentity ColorIdentity { get; set; }
}

