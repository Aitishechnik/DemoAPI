using DemoAPI.Models;
using DemoAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPI.Controllers
{
    [ApiController]
    [Route("garage")]
    public class GarageController : ControllerBase
    {
        private IGarageService _garageService;

        public GarageController(IGarageService garageService)
        {
            _garageService = garageService;
        }

        [Authorize]
        [HttpGet("autopark")]
        public async Task<IActionResult> GetAutoPark()
        {
            var autopark = await _garageService.GetAutoPark();
            return Ok(autopark);
        }

        [Authorize]
        [HttpPost("cars")]
        public async Task<IActionResult> AddNewCar([FromBody] ParamsForAuto paramsForAuto)
        {
            var carId = await _garageService.AddNewCar(paramsForAuto);

            return Ok(carId);
        }

        [Authorize]
        [HttpPost("garage")]
        public async Task<IActionResult> AddGarage(string name)
        {
            var garageId = await _garageService.AddGarage(name);

            return Ok(new { garageId });
        }


    }
}
