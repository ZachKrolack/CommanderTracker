using CommanderTracker.Models;

namespace CommanderTracker.DTOs;

public static class PlayGroupDeckDTOMapper
{
    public static PlayGroupDeckBaseResponseDTO ToPlayGroupDeckBaseResponseDTO(PlayGroupDeck playGroupDeck)
    {
        return new PlayGroupDeckBaseResponseDTO
        {
            Id = playGroupDeck.Id,
            Deck = DeckDTOMapper.ToDeckBaseResponseDTO(playGroupDeck.Deck),
            PlayGroupId = playGroupDeck.PlayGroupId,
            CreatedDate = playGroupDeck.CreatedDate,
            UpdatedDate = playGroupDeck.UpdatedDate,
            CreatedById = playGroupDeck.CreatedById,
            UpdatedById = playGroupDeck.UpdatedById
        };
    }

    public static PlayGroupDeckResponseDTO ToPlayGroupDeckResponseDTO(PlayGroupDeck playGroupDeck)
    {
        return new PlayGroupDeckResponseDTO
        {
            Id = playGroupDeck.Id,
            Deck = DeckDTOMapper.ToDeckBaseResponseDTO(playGroupDeck.Deck),
            PlayGroupId = playGroupDeck.PlayGroupId,
            PlayInstances = playGroupDeck.PlayInstances.Select(PlayInstanceDTOMapper.ToDeckPlayInstanceResponseDTO).ToList(),
            CreatedDate = playGroupDeck.CreatedDate,
            UpdatedDate = playGroupDeck.UpdatedDate,
            CreatedById = playGroupDeck.CreatedById,
            UpdatedById = playGroupDeck.UpdatedById
        };
    }

    public static PlayGroupDeck ToPlayGroupDeck(PlayGroupDeckCreateRequestDTO request, Guid playGroupId, string createdById)
    {
        return new PlayGroupDeck {
            DeckId = request.DeckId,
            PlayGroupId = playGroupId,
            CreatedById = createdById,
            UpdatedById = createdById
        };
    }
}
