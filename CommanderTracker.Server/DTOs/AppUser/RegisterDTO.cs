using System.ComponentModel.DataAnnotations;

namespace CommanderTracker.DTOs;

public class RegisterDTO
{
    public required string UserName { get; set; } = string.Empty;

    [EmailAddress]
    public required string Email { get; set; } = string.Empty;
    public required string Password { get; set; } = string.Empty;
}
