using DemoAPI.Data.Entities;
using DemoAPI.Models;
namespace DemoAPI.Services
{
    public interface IWarehouseService
    {
        Task <List<ItemEntity>> CheckItemsInStock();
        Task <ItemEntity> GetItemByID(long id);
        Task <bool> AddNewItem(ParamsForItem paramsForItem);
        Task <bool> RemoveItem(long id);
        Task <bool> SetQuantity(long id, int quantity);
        Task <bool> SetCost(long id, int cost);
        Task <bool> SetPrice(long id, int price);
    }
}
