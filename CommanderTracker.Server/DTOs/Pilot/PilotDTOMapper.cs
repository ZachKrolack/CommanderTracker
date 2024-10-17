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
            CreatedDate = pilot.CreatedDate,
            UpdatedDate = pilot.UpdatedDate
        };
    }

    public static PilotResponseDTO ToPilotResponseDTO(Pilot pilot)
    {
        return new PilotResponseDTO
        {
            Id = pilot.Id,
            Name = pilot.Name,
            PlayGroup = PlayGroupDTOMapper.ToPlayGroupBaseResponseDTO(pilot.PlayGroup),
            // CreatedBy = AppUserDTOMapper.ToAppUserResponseDTO(pilot.CreatedBy),
            PlayInstances = pilot.PlayInstances.Select(PlayInstanceDTOMapper.ToPilotPlayInstanceResponseDTO).ToList(),
            CreatedDate = pilot.CreatedDate,
            UpdatedDate = pilot.UpdatedDate
        };
    }

    public static Pilot ToPilot(PilotCreateRequestDTO request, Guid playGroupId, string createdById, bool self = false) // TODO
    {
        return new Pilot
        { 
            Name = request.Name,
            AppUserId = self ? createdById : request.AppUserId,
            PlayGroupId = playGroupId,
            CreatedById = createdById,
            UpdatedById = createdById
        };
    }
}
