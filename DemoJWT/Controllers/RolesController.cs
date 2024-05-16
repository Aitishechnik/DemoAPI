using DemoJWT.Data;
using DemoJWT.Data.Entities;
using DemoJWT.Models.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoJWT.Controllers
{
    [ApiController]
    [Route("roles")]
    public class RolesController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<long>> _roleManager;
        private readonly DataContext _context;

        public RolesController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<long>> roleManager, DataContext dataContext)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = dataContext;
        }

        [Authorize(Roles = RoleConsts.Administrator, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

        [Authorize(Roles = RoleConsts.Administrator, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("GetUserRolesByEmail/{email}")]
        public async Task<IActionResult> GetUserRoleByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return BadRequest("User not found.");
            }

            var roleIds = await _context.UserRoles.Where(r => r.UserId == user.Id).Select(x => x.RoleId).ToListAsync();
            var rolesNames = _context.Roles.Where(x => roleIds.Contains(x.Id)).ToList();
            string allRoles = string.Empty;
            for(int i = 0; i < rolesNames.Count; i++)
                allRoles += rolesNames[i].Name + ";\n";

            if (rolesNames == null)
            {
                return BadRequest("User has no role.");
            }

            return Ok(rolesNames);
        }
    }
}
