using System.Security.Claims;
using WildlifePoaching.API.Models.Domain;

namespace WildlifePoaching.API.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateJwtToken(User user);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
