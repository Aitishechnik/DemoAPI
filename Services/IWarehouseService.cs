using DemoAPI.Models;
namespace DemoAPI.Services
{
    public interface IWarehouseService
    {
        List<Item> CheckItemsInStock();
        Item GetItemByID(long id);
        bool AddNewItem(ParamsForItem paramsForItem);
        bool AddNewItemWithID(ParamsForItemWithID paramsForItemWithID);
        bool RemoveItem(long id);
        bool SetQuantity(long id, int quantity);
        bool SetCost(long id, int cost);
        bool SetPrice(long id, int price);
    }
}
