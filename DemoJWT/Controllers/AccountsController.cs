using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DemoJWT.Data;
using DemoJWT.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using DemoJWT.Extensions;
using DemoJWT.Models.Identity;
using DemoJWT.Services.Identity;
using System.Data;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Authorization;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
namespace DemoJWT.Controllers
{
    [ApiController]
    [Route("accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<long>> _roleManager;
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;

        public AccountsController(ITokenService tokenService, DataContext context, UserManager<ApplicationUser> userManager, IConfiguration configuration, RoleManager<IdentityRole<long>> roleManager)
        {
            _tokenService = tokenService;
            _context = context;
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }

        [Authorize(Roles = RoleConsts.Moderator, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("AddUserRole")]
        public async Task<IActionResult> AddUserRole(long userId, string newRoleName)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user is null)
                return NotFound($"User with ID {userId} not found");

            if (user.Id == RoleConsts.AdminID)
                return BadRequest("You can't change admin role");

            if (!await _roleManager.RoleExistsAsync(newRoleName))
                return BadRequest("Bad role name");

            await _userManager.AddToRoleAsync(user, newRoleName);

            return Ok();
        }

        [Authorize]
        [HttpGet("GetUserRoleByEmail/{email}")]
        public async Task<IActionResult> GetUserRoleByEmail(string email)
        {
            if (User.IsInRole(RoleConsts.Administrator))
            {

                var user = await _userManager.FindByEmailAsync(email);

                if (user == null)
                {
                    return BadRequest("User not found.");
                }

                var roleIds = await _context.UserRoles.Where(r => r.UserId == user.Id).Select(x => x.RoleId).ToListAsync();
                var result = _context.Roles.Where(x => roleIds.Contains(x.Id)).ToList()[0].Name;

                if (result == null)
                {
                    return BadRequest("User has no role.");
                }

                return Ok(result);
            }

            return BadRequest("No access to this method");
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Authenticate([FromBody] AuthRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var managedUser = await _userManager.FindByEmailAsync(request.Email);

            if (managedUser == null)
            {
                return BadRequest("Bad credentials");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, request.Password);

            if (!isPasswordValid)
            {
                return BadRequest("Bad credentials");
            }

            var user = _context.Users.FirstOrDefault(u => u.Email == request.Email);

            if (user is null)
                return Unauthorized();

            var roleIds = await _context.UserRoles.Where(r => r.UserId == user.Id).Select(x => x.RoleId).ToListAsync();
            var roles = _context.Roles.Where(x => roleIds.Contains(x.Id)).ToList();

            var accessToken = _tokenService.CreateToken(user, roles);
            user.RefreshToken = _configuration.GenerateRefreshToken();
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(_configuration.GetSection("Jwt:RefreshTokenValidityInDays").Get<int>());

            await _context.SaveChangesAsync();

            return Ok(new AuthResponse
            {
                Username = user.UserName!,
                Email = user.Email!,
                Token = accessToken,
                RefreshToken = user.RefreshToken
            });
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthResponse>> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(request);

            var user = new ApplicationUser
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddleName = request.MiddleName,
                Email = request.Email,
                UserName = request.Email
            };
            var result = await _userManager.CreateAsync(user, request.Password);

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            if (!result.Succeeded) return BadRequest(request);

            var findUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);

            if (findUser == null) throw new Exception($"User {request.Email} not found");

            await _userManager.AddToRoleAsync(findUser, RoleConsts.Member);

            return await Authenticate(new AuthRequest
            {
                Email = request.Email,
                Password = request.Password
            });
        }

        [HttpPost]
        [Route("refresh-token")]
        public async Task<IActionResult> RefreshToken(TokenModel? tokenModel)
        {
            if (tokenModel is null)
            {
                return BadRequest("Invalid client request");
            }

            var accessToken = tokenModel.AccessToken;
            var refreshToken = tokenModel.RefreshToken;
            var principal = _configuration.GetPrincipalFromExpiredToken(accessToken);

            if (principal == null)
            {
                return BadRequest("Invalid access token or refresh token");
            }

            var username = principal.Identity!.Name;
            var user = await _userManager.FindByNameAsync(username!);

            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                return BadRequest("Invalid access token or refresh token");
            }

            var newAccessToken = _configuration.CreateToken(principal.Claims.ToList());
            var newRefreshToken = _configuration.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            await _userManager.UpdateAsync(user);

            return new ObjectResult(new
            {
                accessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                refreshToken = newRefreshToken
            });
        }

        [Authorize]
        [HttpPost("revoke/{username}")]
        public async Task<IActionResult> Revoke(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null) return BadRequest("Invalid user name");

            user.RefreshToken = null;
            await _userManager.UpdateAsync(user);

            return Ok();
        }

        [Authorize]
        [HttpPost("revoke-all")]
        public async Task<IActionResult> RevokeAll()
        {
            var users = _userManager.Users.ToList();
            foreach (var user in users)
            {
                user.RefreshToken = null;
                await _userManager.UpdateAsync(user);
            }

            return Ok();
        }
    }
}
