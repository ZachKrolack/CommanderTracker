using CommanderTracker.Models;
using CommanderTracker.Models.DTO;

namespace CommanderTracker.Model.DTO;

public static class PlayGroupDeckDTOMapper
{
    public static PlayGroupDeckBaseResponseDTO ToPlayGroupDeckBaseResponseDTO(PlayGroupDeck playGroupDeck)
    {
        return new PlayGroupDeckBaseResponseDTO
        {
            Id = playGroupDeck.Id,
            Deck = DeckDTOMapper.ToDeckBaseResponseDTO(playGroupDeck.Deck),
            Pilot = playGroupDeck.Pilot != null ? PilotDTOMapper.ToPilotBaseResponseDTO(playGroupDeck.Pilot) : null,
            CreatedDate = playGroupDeck.CreatedDate,
            UpdatedDate = playGroupDeck.UpdatedDate
        };
    }

    public static PlayGroupDeckResponseDTO ToPlayGroupDeckResponseDTO(PlayGroupDeck playGroupDeck)
    {
        return new PlayGroupDeckResponseDTO
        {
            Id = playGroupDeck.Id,
            Deck = DeckDTOMapper.ToDeckBaseResponseDTO(playGroupDeck.Deck),
            Pilot = playGroupDeck.Pilot != null ? PilotDTOMapper.ToPilotBaseResponseDTO(playGroupDeck.Pilot) : null,
            PlayInstances = playGroupDeck.PlayInstances.Select(PlayInstanceDTOMapper.ToDeckPlayInstanceResponseDTO).ToList(),
            CreatedDate = playGroupDeck.CreatedDate,
            UpdatedDate = playGroupDeck.UpdatedDate
        };
    }

    public static PlayGroupDeck ToPlayGroupDeck(PlayGroupDeckCreateRequestDTO request, Guid playGroupId, string createdById)
    {
        return new PlayGroupDeck {
            DeckId = request.DeckId,
            PlayGroupId = playGroupId,
            PilotId = request.PilotId,
            CreatedById = createdById,
            UpdatedById = createdById
        };
    }
}
