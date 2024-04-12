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
        [Route("ShowUserList")]
        public IActionResult ShowUserList()
        {
            return Ok(userLogService.ShowUserList());
        }

        [HttpPost]
        [Route("AddNewUser")]
        public IActionResult AddNewUser([FromBody] UserParams userParams)
        {
            if (userLogService.AddNewUser(userParams))
            {
                return Ok();
            }

            return BadRequest("Invalid User data");
        }
    }
}
