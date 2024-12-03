namespace CommanderTracker.DTOs;

public class PlayInstanceBaseResponseDTO : BaseResponseDTO
{
    public int TurnOrder { get; set; }
    public int EndPosition { get; set; }
    public string Notes { get; set; } = string.Empty;
}

public class PlayInstanceResponseDTO : PlayInstanceBaseResponseDTO
{
    public required Guid DeckId { get; set; }
    public required Guid GameId { get; set; }
    public required Guid PilotId { get; set; }
    public required Guid PlayGroupId { get; set; }
}

public class DeckPlayInstanceResponseDTO : PlayInstanceBaseResponseDTO
{
    public required GameResponseDTO Game { get; set; }
    public required PilotBaseResponseDTO Pilot { get; set; }
    public required PlayGroupBaseResponseDTO PlayGroup { get; set; }
}

public class GamePlayInstanceResponseDTO : PlayInstanceBaseResponseDTO
{
    public required DeckBaseResponseDTO Deck { get; set; }
    public required PilotBaseResponseDTO Pilot { get; set; }
    public required PlayGroupBaseResponseDTO PlayGroup { get; set; }
}

public class PilotPlayInstanceResponseDTO : PlayInstanceBaseResponseDTO
{
    public required DeckBaseResponseDTO Deck { get; set; }
    public required GameResponseDTO Game { get; set; }
    public required PlayGroupBaseResponseDTO PlayGroup { get; set; }
}
