﻿namespace CommanderTracker.DTOs;

public class PlayGroupBaseResponseDTO : BaseResponseDTO {
    public string Name { get; set; } = string.Empty;
}

public class PlayGroupResponseDTO : PlayGroupBaseResponseDTO
{
    public List<GameBaseResponseDTO> Games { get; set; } = [];
    public List<PilotBaseResponseDTO> Pilots { get; set; } = [];
    public List<PlayGroupDeckBaseResponseDTO> Decks { get; set; } = [];
}