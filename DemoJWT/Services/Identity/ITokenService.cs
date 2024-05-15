using DemoJWT.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace DemoJWT.Services.Identity
{
    public interface ITokenService
    {
        string CreateToken(ApplicationUser user, List<IdentityRole<long>> role);
    }
}
