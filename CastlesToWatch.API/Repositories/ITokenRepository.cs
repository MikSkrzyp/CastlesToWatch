using Microsoft.AspNetCore.Identity;

namespace CastlesToWatch.API.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
