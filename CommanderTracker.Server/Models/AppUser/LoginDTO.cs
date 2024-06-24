namespace CommanderTracker.Models.DTO;

public class LoginDTO
{
    public required string UserName { get; set; } = string.Empty;
    public required string Password { get; set;} = string.Empty;
}
