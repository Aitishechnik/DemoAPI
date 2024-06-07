using DemoAPI.Data.Entities;
using DemoAPI.Models;
using Microsoft.AspNetCore.Components.Web;
namespace DemoAPI.Services
{
    public interface IGarageService
    {
        Task<long> AddNewCar(ParamsForAuto paramsForAuto);
        Task<List<AutoEntity>> GetAutoPark();
        Task<long> AddGarage(string name);
    }
}