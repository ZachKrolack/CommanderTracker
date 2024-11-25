using CommanderTracker.Models;

namespace CommanderTracker.DTOs;

public class GameDTOMapper
{
    public static GameBaseResponseDTO ToGameBaseResponseDTO(Game game)
    {
        return new GameBaseResponseDTO
        {
            Id = game.Id,
            Notes = game.Notes,
            Turns = game.Turns,
            CreatedDate = game.CreatedDate,
            UpdatedDate = game.UpdatedDate,
            CreatedById = game.CreatedById,
            UpdatedById = game.UpdatedById
        };
    }

    public static GameResponseDTO ToGameResponseDTO(Game game)
    {
        return new GameResponseDTO
        {
            Id = game.Id,
            Notes = game.Notes,
            Turns = game.Turns,
            CreatedDate = game.CreatedDate,
            UpdatedDate = game.UpdatedDate,
            CreatedById = game.CreatedById,
            UpdatedById = game.UpdatedById,
            PlayGroup = PlayGroupDTOMapper.ToPlayGroupBaseResponseDTO(game.PlayGroup),
            PlayInstances = game.PlayInstances.Select(PlayInstanceDTOMapper.ToGamePlayInstanceResponseDTO).ToList()
        };
    }

    public static Game ToGame(GameCreateRequestDTO request, Guid playGroupId, string createdById) { // TODO
        return new Game
        {
            Turns = request.Turns,
            Notes = request.Notes,
            PlayGroupId = playGroupId,
            CreatedById = createdById,
            UpdatedById = createdById
        };
    }
}
