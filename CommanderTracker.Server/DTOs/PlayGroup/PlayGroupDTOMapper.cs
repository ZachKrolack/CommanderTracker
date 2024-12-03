using CommanderTracker.Models;

namespace CommanderTracker.DTOs;

public static class PlayGroupDTOMapper
{
    public static PlayGroupBaseResponseDTO ToPlayGroupBaseResponseDTO(PlayGroup playGroup)
    {
        return new PlayGroupBaseResponseDTO
        {
            Id = playGroup.Id,
            Name = playGroup.Name,
            CreatedDate = playGroup.CreatedDate,
            UpdatedDate = playGroup.UpdatedDate,
            CreatedById = playGroup.CreatedById,
            UpdatedById = playGroup.UpdatedById
        };
    }

    public static PlayGroupResponseDTO ToPlayGroupResponseDTO(PlayGroup playGroup)
    {
        return new PlayGroupResponseDTO
        {
            Id = playGroup.Id,
            Name = playGroup.Name,
            Games = playGroup.Games.Select(GameDTOMapper.ToGameBaseResponseDTO).ToList(),
            Pilots = playGroup.Pilots.Select(PilotDTOMapper.ToPilotBaseResponseDTO).ToList(),
            Decks = playGroup.Decks.Select(DeckDTOMapper.ToDeckBaseResponseDTO).ToList(),
            CreatedDate = playGroup.CreatedDate,
            UpdatedDate = playGroup.UpdatedDate,
            CreatedById = playGroup.CreatedById,
            UpdatedById = playGroup.UpdatedById
        };
    }

    public static PlayGroup ToPlayGroup(PlayGroupCreateRequestDTO request, string createdById)
    {
        return new PlayGroup
        {
            Name = request.Name,
            CreatedById = createdById,
            UpdatedById = createdById
        };
    }
}
