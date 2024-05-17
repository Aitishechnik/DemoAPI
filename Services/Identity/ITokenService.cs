using DemoAPI.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace DemoAPI.Services.Identity
{
    public interface ITokenService
    {
        string CreateToken(ApplicationUser user, List<IdentityRole<long>> role);
    }
}
