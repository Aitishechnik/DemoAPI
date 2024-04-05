using DemoAPI.Models;
using Microsoft.AspNetCore.Components.Web;
namespace DemoAPI.Services
{
    public interface IGarageService
    {
        List<Auto> CheckAutoPark();
        bool AddNewCar(ParamsForAuto paramsForAuto);
    }
}
