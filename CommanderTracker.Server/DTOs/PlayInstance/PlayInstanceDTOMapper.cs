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
            // DeckId = playInstance.DeckId,
            PlayGroupDeckId = playInstance.PlayGroupDeckId,
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
            // Deck = DeckDTOMapper.ToDeckBaseResponseDTO(playInstance.Deck),
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
            // Deck = DeckDTOMapper.ToDeckBaseResponseDTO(playInstance.Deck),
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
            // DeckId = request.DeckId,
            PlayGroupDeckId = request.PlayGroupDeckId,
            PilotId = request.PilotId,
            GameId = gameId,
            CreatedById = createdById,
            UpdatedById = createdById
        };
    }
}
