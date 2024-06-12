using Microsoft.AspNetCore.Mvc;
using DemoAPI.Services;
using DemoAPI.Models;
                                                                               
namespace DemoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserLogService userLogService;

        public UsersController(IUserLogService userLogService)
        {
            this.userLogService = userLogService;
        }

        [HttpGet]
        [Route("show-user-list")]
        public async Task<IActionResult> ShowUserList()
        {
            var result = await userLogService.ShowUserList();
            return Ok(result);
        }

        [HttpPost]
        [Route("add-new-user")]
        public async Task<IActionResult> AddNewUser([FromBody] UserParams userParams)
        {
            if (await userLogService.AddNewUser(userParams))
            {
                return Ok();
            }

            return BadRequest("Invalid User data");
        }

        [HttpDelete]
        [Route("remove-user")]
        public async Task<IActionResult> DeleteUser(long userId)
        {
            if (await userLogService.DeleteUser(userId))
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPatch]
        [Route("update-user")]
        public async Task<IActionResult> UpdateUser(long id ,UserParams userParams)
        {
            if(await userLogService.UpdateUserInfo(id, userParams))
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("create-new-userlog")]
        public async Task<IActionResult> NewUserLog(string name)
        {
            if (userLogService.AddNewUserLog(name).Result)
            {
                await userLogService.AddNewUserLog(name);
                return Ok();
            }

            return BadRequest();
        }
    }
}
