namespace DemoAPI.Models
{
    public class Warehouse
    {
        public Dictionary<long, Item> Stock { get; set; } = new Dictionary<long, Item>();

    }

    public class Item
    {
        private static long globalIdIndex = 1;
        public long Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Category { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public int Quantity { get; private set; }
        public int? Cost { get; private set; }
        public int? Price { get; private set; }

        public Item(string name, string category, string description, int quantity = 0, int cost = 0, int price = 0)
        {
            Id = globalIdIndex++;
            Name = name;
            Category = category;
            Description = description;
            Quantity = quantity;
            Cost = cost;
            Price = price;
        }

        public Item(long id ,string name, string category, string description, int quantity = 0, int cost = 0, int price = 0)
        {
            Id = id;
            Name = name;
            Category = category;
            Description = description;
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
