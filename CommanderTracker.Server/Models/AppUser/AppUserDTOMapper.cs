namespace CommanderTracker.Models.DTO;

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
