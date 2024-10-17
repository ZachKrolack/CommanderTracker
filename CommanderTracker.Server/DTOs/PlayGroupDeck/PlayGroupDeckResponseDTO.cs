namespace CommanderTracker.DTOs;

public class PlayGroupDeckBaseResponseDTO : BaseResponseDTO
{
    public DeckBaseResponseDTO Deck { get; set; } = null!;
    public PilotBaseResponseDTO? Pilot { get; set; } = null;
}

public class PlayGroupDeckResponseDTO : PlayGroupDeckBaseResponseDTO
{
    public List<DeckPlayInstanceResponseDTO> PlayInstances { get; set; } = [];
}
