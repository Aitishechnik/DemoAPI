using System.ComponentModel;

namespace DemoAPI.Models
{
    public class Item
    {
        private static long globalIdIndex = 1;
        public long Id { get; private set; }

        [DefaultValue(null)]
        public string? Name { get; private set; }
        [DefaultValue(null)]
        public int? Category { get; private set; }
        [DefaultValue(null)]
        public string? Description { get; private set; }
        public int Quantity { get; private set; }
        public int? Cost { get; private set; }
        public int? Price { get; private set; }

        public Item(ParamsForItem paramsForItem, int quantity = 0, int cost = 0, int price = 0)
        {
            Id = globalIdIndex++;
            Name = paramsForItem.Name;
            Category = paramsForItem.Category;
            Description = paramsForItem.Description;
            Quantity = quantity;
            Cost = cost;
            Price = price;
        }

        public Item(ParamsForItemWithID paramsForItemWithID, int quantity = 0, int cost = 0, int price = 0)
        {
            Id = (long)paramsForItemWithID.Id;
            Name = paramsForItemWithID.Name;
            Category = paramsForItemWithID.Category;
            Description = paramsForItemWithID.Description;
            Quantity = quantity;
            Cost = cost;
            Price = price;
        }

        public static long GetGlobalIdIndex()
        {
            return globalIdIndex;
        }

        public static void RaiseGlobalIdIndex()
        {
            globalIdIndex++;
        }

        public void SetQuantity(int quantity)
        {
            Quantity = quantity;
        }

        public void SetCost(int cost)
        {
            Cost = cost;
        }

        public void SetPrice(int price)
        {
            Price = price;
        }
    }
}
