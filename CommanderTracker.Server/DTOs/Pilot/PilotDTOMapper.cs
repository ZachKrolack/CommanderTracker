using CommanderTracker.Enums;
using CommanderTracker.Models;

namespace CommanderTracker.DTOs;

public class PilotDTOMapper
{
    public static PilotBaseResponseDTO ToPilotBaseResponseDTO(Pilot pilot)
    {
        return new PilotBaseResponseDTO
        {
            Id = pilot.Id,
            Name = pilot.Name,
            Role = pilot.Role, // TODO
            PlayGroupId = pilot.PlayGroupId,
            CreatedDate = pilot.CreatedDate,
            UpdatedDate = pilot.UpdatedDate,
            CreatedById = pilot.CreatedById,
            UpdatedById = pilot.UpdatedById
        };
    }

    public static PilotResponseDTO ToPilotResponseDTO(Pilot pilot)
    {
        return new PilotResponseDTO
        {
            Id = pilot.Id,
            Name = pilot.Name,
            Role = pilot.Role, // TODO
            PlayGroupId = pilot.PlayGroupId,
            PlayGroup = PlayGroupDTOMapper.ToPlayGroupBaseResponseDTO(pilot.PlayGroup),
            PlayInstances = pilot.PlayInstances.Select(PlayInstanceDTOMapper.ToPilotPlayInstanceResponseDTO).ToList(),
            CreatedDate = pilot.CreatedDate,
            UpdatedDate = pilot.UpdatedDate,
            CreatedById = pilot.CreatedById,
            UpdatedById = pilot.UpdatedById
        };
    }

    public static Pilot ToPilot(PilotCreateRequestDTO request, Guid playGroupId, string createdById, bool self = false) // TODO
    {
        return new Pilot
        { 
            Name = request.Name,
            Role = self ? PilotRole.Owner : PilotRole.Member,
            AppUserId = self ? createdById : request.AppUserId,
            PlayGroupId = playGroupId,
            CreatedById = createdById,
            UpdatedById = createdById
        };
    }
}
