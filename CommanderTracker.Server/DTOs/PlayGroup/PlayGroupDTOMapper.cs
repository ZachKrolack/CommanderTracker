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
            UpdatedDate = playGroup.UpdatedDate
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
            Decks = playGroup.PlayGroupDecks.Select(PlayGroupDeckDTOMapper.ToPlayGroupDeckBaseResponseDTO).ToList(),
            // CreatedBy = AppUserDTOMapper.ToAppUserResponseDTO(playGroup.CreatedBy),
            CreatedDate = playGroup.CreatedDate,
            UpdatedDate = playGroup.UpdatedDate
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
