using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CommanderTracker.Server.Extensions
{
    public static class ClaimsExtensions
    {
        public static string GetId(this ClaimsPrincipal principal)
        {
            return principal.Claims.FirstOrDefault(claim => claim.Type.Equals(ClaimTypes.NameIdentifier)).Value;
        }
    }
}
