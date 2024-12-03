namespace CommanderTracker.DTOs;

public class PlayGroupDeckBaseResponseDTO : BaseResponseDTO
{
    public DeckBaseResponseDTO Deck { get; set; } = null!;
    public Guid PlayGroupId { get; set; }
}

public class PlayGroupDeckResponseDTO : PlayGroupDeckBaseResponseDTO
{
    public List<DeckPlayInstanceResponseDTO> PlayInstances { get; set; } = [];
}
