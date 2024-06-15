using Microsoft.AspNetCore.Mvc;
using DemoAPI.Services;
using DemoAPI.Models;
namespace DemoAPI.Controllers
{
    [ApiController]
    [Route("storage")]
    public class WarehouseController : ControllerBase
    {
        private IWarehouseService _warehouseService;

        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        [HttpGet("check-positions-in-stock")]
        public async Task<IActionResult> CheckPositionsInStock()
        {
            var list = await _warehouseService.CheckItemsInStock();
            return Ok(list);
        }

        [HttpGet("get-item")]
        public async Task<IActionResult> GetItem([FromHeader]long id)
        {
            var item = await _warehouseService.GetItemByID(id);
            if (item != null)
                return Ok(item);

            return BadRequest($"No item with Id:{id} in stock");
        }

        [HttpPost("set-new-position")]
        public async Task<IActionResult> SetNewPosition([FromBody]ParamsForItem paramsForItem)
        {
            if(await _warehouseService.AddNewItem(paramsForItem))
            return Ok();

            return BadRequest("Invalid params");
        }

        [HttpPatch]
        [Route("set-quantity")]
        public async Task<IActionResult> SetQuantity(long id, int quantity)
        {
            if (await _warehouseService.SetQuantity(id, quantity))
                return Ok();

            return BadRequest();
        }

        [HttpPatch]
        [Route("set-cost")]
        public async Task<IActionResult> SetCost(long id, int cost)
        {
            if (await _warehouseService.SetCost(id, cost))
                return Ok();

            return BadRequest();
        }

        [HttpPatch]
        [Route("set-price")]
        public async Task<IActionResult> SetPrice(long id, int price)
        {
            if (await _warehouseService.SetPrice(id, price))
                return Ok();

            return BadRequest();
        }

        [HttpDelete]
        [Route("remove-item")]
        public async Task<IActionResult> RemoveItem(long id)
        {
            if (await _warehouseService.RemoveItem(id))
                return Ok();

            return BadRequest();
        }
    }
}
