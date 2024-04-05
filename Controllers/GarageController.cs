using DemoAPI.Models;
using DemoAPI.Services;
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

        [HttpGet]
        [Route("CheckAutoPark")]
        public IActionResult CheckAutoPark()
        {
            return Ok(garageService.CheckAutoPark());
        }

        [HttpPost]
        [Route("AddNewCar")]
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
