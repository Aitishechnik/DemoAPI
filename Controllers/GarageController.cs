using DemoAPI.Models;
using DemoAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPI.Controllers
{
    [ApiController]
    [Route("Garage")]
    public class GarageController : ControllerBase
    {
        private IGarageService garageService;

        public GarageController(IGarageService garageService)
        {
            this.garageService = garageService;
        }

        [Authorize]
        [HttpGet("CheckAutoPark")]
        public IActionResult CheckAutoPark()
        {
            return Ok(garageService.CheckAutoPark());
        }

        [Authorize]
        [HttpPost("AddNewCar")]
        public IActionResult AddNewCar([FromBody]ParamsForAuto paramsForAuto)
        {
            if (garageService.AddNewCar(paramsForAuto))
            {
                return Ok();
            }

            return BadRequest("Invalid Params");
        }

        
    }
}
