using DemoAPI.Models;

namespace DemoAPI.Services
{
    public class GarageService : IGarageService
    {
        private Garage Garage { get; }

        public GarageService(Garage garage)
        {
            Garage = garage;
        }
        public bool AddNewCar(ParamsForAuto paramsForAuto)
        {
            if (paramsForAuto.CheckParams())
            {
                if(Garage.CarPark.ContainsKey((long)paramsForAuto.Id))
                    return false;
                var auto = new Auto(paramsForAuto);
                Garage.CarPark.Add(auto.Id, auto);
                return true;
            }

            return false;
        }

        public List<Auto> CheckAutoPark()
        {
            return Garage.CarPark.Values.ToList();
        }
    }
}
