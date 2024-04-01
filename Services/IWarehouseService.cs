using DemoAPI.Models;
namespace DemoAPI.Services
{
    public interface IWarehouseService
    {
        protected Warehouse warehouse { get; }
        List<Item> CheckItemsInStock();
        Item GetItemByID(long id);
        void AddNewItem(string name, string category, string description);
        bool AddNewItemWithID(long id, string name, string category, string description);
        bool RemoveItem(long id);
        bool SetQuantity(long id, int quantity);
        bool SetCost(long id, int cost);
        bool SetPrice(long id, int price);
    }
}
