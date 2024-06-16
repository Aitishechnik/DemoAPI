using DemoAPI.Data;
using DemoAPI.Data.Entities;
using DemoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Services
{
    public class WarehouseService : IWarehouseService
    {
        private DataContext _dataContext;

        public WarehouseService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> AddNewItem(ParamsForItem paramsForItem)
        {
            if (await _dataContext.Items.FirstOrDefaultAsync(item => item.Id == paramsForItem.Id) == null)
            {
                var newItem = new ItemEntity(paramsForItem);
                await _dataContext.Items.AddAsync(newItem);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<ItemEntity>> CheckItemsInStock()
        {
            return await _dataContext.Items.ToListAsync();
        }

        public async Task<ItemEntity> GetItemByID(long id)
        {
            return await _dataContext.Items.FirstOrDefaultAsync(item => item.Id == id);
        }

        public async Task<bool> RemoveItem(long id)
        {
            var item = await _dataContext.Items.FindAsync(id);
            if (item != null)
            {
                _dataContext.Items.Remove(item);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> SetCost(long id, int cost)
        {
            var item = await _dataContext.Items.FindAsync(id);

            if (item != null)
            {
                item.SetCost(cost);
                _dataContext.Items.Update(item);
                await _dataContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> SetPrice(long id, int price)
        {
            var item = await _dataContext.Items.FindAsync(id);

            if(item != null)
            {
                item.SetQuantity(price);
                _dataContext.Items.Update(item);
                await _dataContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> SetQuantity(long id, int quantity)
        {
            var item = await _dataContext.Items.FindAsync(id);

            if (item != null)
            {
                item.SetQuantity(quantity);
                _dataContext.Items.Update(item);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
