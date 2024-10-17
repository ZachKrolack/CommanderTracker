namespace CommanderTracker.DTOs;

public class TokenDTO
{
    public string Token { get; set; } = string.Empty;
    public DateTime Expires { get; set; }
}
