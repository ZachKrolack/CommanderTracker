namespace CommanderTracker.Models.DTO;

public class DeckDTOMapper
{
    public static DeckBaseResponseDTO ToDeckBaseResponseDTO(Deck deck)
    {
        return new DeckBaseResponseDTO
        {
            Id = deck.Id,
            Name = deck.Name,
            ColorIdentity = deck.ColorIdentity,
            CreatedDate = deck.CreatedDate,
            UpdatedDate = deck.UpdatedDate,
        };
    }

    public static DeckResponseDTO ToDeckResponseDTO(Deck deck)
    {
        return new DeckResponseDTO
        {
            Id = deck.Id,
            Name = deck.Name,
            ColorIdentity = deck.ColorIdentity,
            CreatedBy = AppUserDTOMapper.ToAppUserResponseDTO(deck.CreatedBy),
            PlayInstances = deck.PlayInstances.Select(PlayInstanceDTOMapper.ToDeckPlayInstanceResponseDTO).ToList(),
            CreatedDate = deck.CreatedDate,
            UpdatedDate = deck.UpdatedDate,
        };
    }

    public static Deck ToDeck(DeckCreateRequestDTO request, string createdById)
    {
        return new Deck
        { 
            Name = request.Name,
            ColorIdentity = request.ColorIdentity,
            CreatedById = createdById,
            UpdatedById = createdById
        };
    }
}
