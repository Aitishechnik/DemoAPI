using DemoAPI.Data;
using DemoAPI.Data.Entities;
using DemoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Services
{
    public class GarageService : IGarageService
    {
        private readonly DataContext _context;

        public GarageService(DataContext context)
        {
            _context = context;
        }

        public async Task<long> AddNewCar(ParamsForAuto paramsForAuto)
        {
            var car = new AutoEntity
            {
                EngineType = paramsForAuto.EngineType,
                HorsePower = paramsForAuto.HorsePower,
                Brand = paramsForAuto.Brand,
                GarageId = paramsForAuto.GarageId,
                Model = paramsForAuto.Model             
            };

            if (car.GarageId == null!)
                car.Garage = await _context.Garages.FindAsync(paramsForAuto.GarageId);

            var entity = await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();

            return entity.Entity.Id;
        }

        public async Task<long> AddGarage(string name)
        {
            var garage = new GarageEntity
            {
                Name = name
            };

            var entity = await _context.Garages.AddAsync(garage);
            await _context.SaveChangesAsync();

            return entity.Entity.Id;
        }

        public async Task<List<AutoEntity>> GetAutoPark()
        {
            return await _context.Cars.ToListAsync();
        }
    }
}
