using DemoAPI.Models;
using Microsoft.Extensions.Hosting;

namespace DemoAPI.Services
{
    public class WarehouseService : IWarehouseService
    {
        public Warehouse warehouse { get; }

        public WarehouseService(Warehouse warehouse)
        {
            this.warehouse = warehouse;
        }

        public void AddNewItem(string name, string category, string description)
        {
            while(warehouse.Stock.ContainsKey(Item.GetGlobalIdIndex()))
            {
                Item.RaiseGlobalIdIndex();
            }

            var item = new Item(name, category, description);
            warehouse.Stock.Add(item.Id, item);
        }

        public Item GetItemByID(long id)
        {
            if (warehouse.Stock.ContainsKey(id))
                return warehouse.Stock[id];

            return null;
        }

        public List<Item> CheckItemsInStock()
        {
            List<Item> items = new List<Item>();
            foreach (var item in warehouse.Stock)
            {
                items.Add(item.Value);
            }
            return items;
        }

        public bool RemoveItem(long id)
        {
            if (warehouse.Stock.TryGetValue(id, out var item))
            {
                warehouse.Stock.Remove(id);
                return true;
            }
            else { return false; }
        }

        public bool SetCost(long id, int cost)
        {
            if (warehouse.Stock.TryGetValue(id, out var item))
            {
                item.SetCost(cost);
                return true;
            }
            else { return false; }
        }

        public bool SetPrice(long id, int price)
        {
            if (warehouse.Stock.TryGetValue(id, out var item))
            {
                item.SetPrice(price);
                return true;
            }
            else { return false; }
        }

        public bool SetQuantity(long id, int quantity)
        {
            if(warehouse.Stock.TryGetValue(id, out var item))
            {
                item.SetQuantity(quantity);
                return true;
            }
            else { return false; }
        }

        public bool AddNewItemWithID(long id, string name, string category, string description)
        {
            if (!warehouse.Stock.ContainsKey(id))
            {
                var item = new Item(id, name, description, category);
                warehouse.Stock.Add(id, item);
                return true;
            }

            return false;
        }
    }
}
