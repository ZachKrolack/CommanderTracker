namespace CommanderTracker.DTOs;

public class PilotBaseResponseDTO : BaseResponseDTO
{
    public required string Name { get; set; } = string.Empty;
    
}

public class PilotResponseDTO : PilotBaseResponseDTO
{
    public required PlayGroupBaseResponseDTO PlayGroup { get; set; } = null!;
    public required List<PilotPlayInstanceResponseDTO> PlayInstances { get; set; } = [];
}
