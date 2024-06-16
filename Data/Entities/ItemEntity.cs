using DemoAPI.Models;

namespace DemoAPI.Data.Entities
{
    public class ItemEntity : BaseEntity
    {
        public string? Name { get; private set; }
        public int? Category { get; private set; }
        public string? Description { get; private set; }
        public int Quantity { get; private set; }
        public int? Cost { get; private set; }
        public int? Price { get; private set; }

        public ItemEntity() { }

        public ItemEntity(ParamsForItem paramsForItem, int quantity = 0, int cost = 0, int price = 0)
        {
            Id = paramsForItem.Id;
            Name = paramsForItem.Name;
            Category = paramsForItem.Category;
            Description = paramsForItem.Description;
            Quantity = quantity;
            Cost = cost;
            Price = price;
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
