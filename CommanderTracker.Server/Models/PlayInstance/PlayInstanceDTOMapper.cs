using CommanderTracker.Models.DTO;

namespace CommanderTracker.Models;

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
            CreatedDate = playInstance.CreatedDate,
            UpdatedDate = playInstance.UpdatedDate
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
            Deck = DeckDTOMapper.ToDeckBaseResponseDTO(playInstance.Deck),
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
            Deck = DeckDTOMapper.ToDeckBaseResponseDTO(playInstance.Deck),
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
            DeckId = request.DeckId,
            PilotId = request.PilotId,
            GameId = gameId,
            CreatedById = createdById,
            UpdatedById = createdById
        };
    }
}
