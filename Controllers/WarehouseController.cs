using Microsoft.AspNetCore.Mvc;
using DemoAPI.Services;
namespace DemoAPI.Controllers
{
    [ApiController]
    [Route("Storage")]
    public class WarehouseController : ControllerBase
    {
        private IWarehouseService warehouseService;

        public WarehouseController(IWarehouseService warehouseService)
        {
            this.warehouseService = warehouseService;
        }

        [HttpGet]
        [Route("CheckPositionsInStock")]
        public IActionResult CheckPositionsInStock()
        {
            return Ok(warehouseService.CheckItemsInStock());
        }

        [HttpGet]
        [Route("GetItem")]
        public IActionResult GetItem(long id)
        {
            var item = warehouseService.GetItemByID(id);
            if (item != null)
                return Ok(item);

            return BadRequest($"No item with Id:{id} in stock");
        }


        [HttpPost]
        [Route("SetNewPosition")]
        public IActionResult SetNewPosition(string name, string category, string description)
        {
            warehouseService.AddNewItem(name, category, description);
            return Ok();
        }

        [HttpPost]
        [Route("SetNewPositionWithID")]
        public IActionResult SetNewPositionWithID(long id, string name, string category, string description)
        {
            if (warehouseService.AddNewItemWithID(id, name, category, description))
                return Ok();

            return BadRequest();
        }

        [HttpPatch]
        [Route("SetQuantity")]
        public IActionResult SetQuantity(long id, int quantity)
        {
            if (warehouseService.SetQuantity(id, quantity))
                return Ok();

            return BadRequest();
        }

        [HttpPatch]
        [Route("SetCost")]
        public IActionResult SetCost(long id, int cost)
        {
            if (warehouseService.SetCost(id, cost))
                return Ok();

            return BadRequest();
        }

        [HttpPatch]
        [Route("SetPrice")]
        public IActionResult SetPrice(long id, int price)
        {
            if (warehouseService.SetPrice(id, price))
                return Ok();

            return BadRequest();
        }

        [HttpDelete]
        [Route("RemoveItem")]
        public IActionResult RemoveItem(long id)
        {
            if (warehouseService.RemoveItem(id))
                return Ok();

            return BadRequest();
        }
    }
}
