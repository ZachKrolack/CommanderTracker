using CommanderTracker.Models;

namespace CommanderTracker.Interfaces;

public interface ITokenService
{
    string CreateToken(AppUser appUser, DateTime expires);
}
