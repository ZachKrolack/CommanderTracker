using CommanderTracker.Enums;

namespace CommanderTracker.DTOs;

public class DeckBaseResponseDTO : BaseResponseDTO
{
    public required string Name { get; set; } = string.Empty;
    public required ColorIdentity ColorIdentity { get; set; }
}

public class DeckResponseDTO : DeckBaseResponseDTO
{
    public required List<PlayGroupBaseResponseDTO> PlayGroups { get; set; }
    public required List<DeckPlayInstanceResponseDTO> PlayInstances { get; set;}
}
