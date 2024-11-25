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
            PlayGroupDeckId = playInstance.PlayGroupDeckId,
            GameId = playInstance.GameId,
            PilotId = playInstance.PilotId,
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
            PlayGroupDeck = PlayGroupDeckDTOMapper.ToPlayGroupDeckBaseResponseDTO(playInstance.PlayGroupDeck),
            Pilot = PilotDTOMapper.ToPilotBaseResponseDTO(playInstance.Pilot)
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
            PlayGroupDeck = PlayGroupDeckDTOMapper.ToPlayGroupDeckBaseResponseDTO(playInstance.PlayGroupDeck),
            Game = GameDTOMapper.ToGameResponseDTO(playInstance.Game)
        };
    }

    public static PlayInstance ToPlayInstance(PlayInstanceCreateRequestDTO request, Guid gameId, string createdById)
    {
        return new PlayInstance
        {
            TurnOrder = request.TurnOrder,
            EndPosition = request.EndPosition,
            Notes = request.Notes,
            PlayGroupDeckId = request.PlayGroupDeckId,
            PilotId = request.PilotId,
            GameId = gameId,
            CreatedById = createdById,
            UpdatedById = createdById
        };
    }
}
