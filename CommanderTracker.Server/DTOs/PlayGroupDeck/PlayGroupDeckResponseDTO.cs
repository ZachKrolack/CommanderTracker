namespace CommanderTracker.DTOs;

public class PlayGroupDeckBaseResponseDTO : BaseResponseDTO
{
    public DeckBaseResponseDTO Deck { get; set; } = null!;
    public PlayGroupBaseResponseDTO PlayGroup { get; set; } = null!;
    // public PilotBaseResponseDTO? Pilot { get; set; } = null; // TODO
}

public class PlayGroupDeckResponseDTO : PlayGroupDeckBaseResponseDTO
{
    public List<DeckPlayInstanceResponseDTO> PlayInstances { get; set; } = [];
}
