using System.Security.Claims;

namespace CommanderTracker.Extensions
{
    public static class ClaimsExtensions
    {
        public static string GetId(this ClaimsPrincipal principal)
        {
            // TODO
            return principal.Claims.FirstOrDefault(claim => claim.Type.Equals(ClaimTypes.NameIdentifier)).Value;
        }
    }
}
