namespace CommanderTracker.DTOs;

public class GameBaseResponseDTO : BaseResponseDTO
{
    public int Turns { get; set; }
    public string Notes { get; set; } = string.Empty;
}


public class GameResponseDTO : GameBaseResponseDTO
{
    public required PlayGroupBaseResponseDTO PlayGroup { get; set; } = null!;
    public required List<GamePlayInstanceResponseDTO> PlayInstances { get; set; } = [];
}
