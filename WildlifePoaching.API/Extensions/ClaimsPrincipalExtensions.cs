using System.Security.Claims;

namespace WildlifePoaching.API.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetUserId(this ClaimsPrincipal principal)
        {
            var claim = principal.FindFirst(ClaimTypes.NameIdentifier);
            return claim != null ? int.Parse(claim.Value) : throw new UnauthorizedAccessException("User ID not found in claims");
        }

        public static string GetUserEmail(this ClaimsPrincipal principal)
        {
            var claim = principal.FindFirst(ClaimTypes.Email);
            return claim?.Value ?? throw new UnauthorizedAccessException("Email not found in claims");
        }

        public static string GetUserRole(this ClaimsPrincipal principal)
        {
            var claim = principal.FindFirst(ClaimTypes.Role);
            return claim?.Value ?? throw new UnauthorizedAccessException("Role not found in claims");
        }
    }
}
