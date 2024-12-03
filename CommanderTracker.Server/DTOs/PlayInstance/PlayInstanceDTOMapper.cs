using CommanderTracker.Models;

namespace CommanderTracker.DTOs;

public class PlayInstanceDTOMapper
{
    public static PlayInstanceResponseDTO ToPlayInstanceResponseDTO(PlayInstance playInstance)
    {
        return new PlayInstanceResponseDTO
        {
            Id = playInstance.Id,
            TurnOrder = playInstance.TurnOrder,
            EndPosition = playInstance.EndPosition,
            Notes = playInstance.Notes,
            DeckId = playInstance.DeckId,
            GameId = playInstance.GameId,
            PilotId = playInstance.PilotId,
            PlayGroupId = playInstance.PlayGroupId,
            CreatedDate = playInstance.CreatedDate,
            UpdatedDate = playInstance.UpdatedDate,
            CreatedById = playInstance.CreatedById,
            UpdatedById = playInstance.UpdatedById
        };
    }

    public static DeckPlayInstanceResponseDTO ToDeckPlayInstanceResponseDTO(PlayInstance playInstance)
    {
        return new DeckPlayInstanceResponseDTO
        {
            Id = playInstance.Id,
            TurnOrder = playInstance.TurnOrder,
            EndPosition = playInstance.EndPosition,
            Notes = playInstance.Notes,
            CreatedDate = playInstance.CreatedDate,
            UpdatedDate = playInstance.UpdatedDate,
            CreatedById = playInstance.CreatedById,
            UpdatedById = playInstance.UpdatedById,
            Game = GameDTOMapper.ToGameResponseDTO(playInstance.Game),
            Pilot = PilotDTOMapper.ToPilotBaseResponseDTO(playInstance.Pilot),
            PlayGroup = PlayGroupDTOMapper.ToPlayGroupBaseResponseDTO(playInstance.PlayGroup)
        };
    }

    public static GamePlayInstanceResponseDTO ToGamePlayInstanceResponseDTO(PlayInstance playInstance)
    {
        return new GamePlayInstanceResponseDTO
        {
            Id = playInstance.Id,
            TurnOrder = playInstance.TurnOrder,
            EndPosition = playInstance.EndPosition,
            Notes = playInstance.Notes,
            CreatedDate = playInstance.CreatedDate,
            UpdatedDate = playInstance.UpdatedDate,
            CreatedById = playInstance.CreatedById,
            UpdatedById = playInstance.UpdatedById,
            Deck = DeckDTOMapper.ToDeckBaseResponseDTO(playInstance.Deck),
            Pilot = PilotDTOMapper.ToPilotBaseResponseDTO(playInstance.Pilot),
            PlayGroup = PlayGroupDTOMapper.ToPlayGroupBaseResponseDTO(playInstance.PlayGroup)
        };
    }

    public static PilotPlayInstanceResponseDTO ToPilotPlayInstanceResponseDTO(PlayInstance playInstance)
    {
        return new PilotPlayInstanceResponseDTO
        {
            Id = playInstance.Id,
            TurnOrder = playInstance.TurnOrder,
            EndPosition = playInstance.EndPosition,
            Notes = playInstance.Notes,
            CreatedDate = playInstance.CreatedDate,
            UpdatedDate = playInstance.UpdatedDate,
            CreatedById = playInstance.CreatedById,
            UpdatedById = playInstance.UpdatedById,
            Deck = DeckDTOMapper.ToDeckBaseResponseDTO(playInstance.Deck),
            Game = GameDTOMapper.ToGameResponseDTO(playInstance.Game),
            PlayGroup = PlayGroupDTOMapper.ToPlayGroupBaseResponseDTO(playInstance.PlayGroup)
        };
    }

    public static PlayInstance ToPlayInstance(PlayInstanceCreateRequestDTO request, Guid gameId, Guid playGroupId, string createdById)
    {
        return new PlayInstance
        {
            TurnOrder = request.TurnOrder,
            EndPosition = request.EndPosition,
            Notes = request.Notes,
            DeckId = request.DeckId,
            GameId = gameId,
            PilotId = request.PilotId,
            PlayGroupDeckId = request.PlayGroupDeckId,
            PlayGroupId = playGroupId,
            CreatedById = createdById,
            UpdatedById = createdById
        };
    }
}
