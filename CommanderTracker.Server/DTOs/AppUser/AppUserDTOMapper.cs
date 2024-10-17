using CommanderTracker.Models;

namespace CommanderTracker.DTOs;

public class AppUserDTOMapper
{
    public static AppUserResponseDTO ToAppUserResponseDTO(AppUser appUser)
    {
        return new AppUserResponseDTO
        {
            Id = appUser.Id,
            UserName = appUser.UserName!
        };
    }
}
