using CommanderTracker.Models;
using CommanderTracker.DTOs;

namespace CommanderTracker.Interfaces;

public interface ITokenService
{
    string CreateToken(AppUser appUser, DateTime expires);
}
