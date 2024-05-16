using System;

namespace DemoAPI.Models
{
    public class Garage
    {
        public Dictionary<long, Auto> CarPark { get; set; } = new Dictionary<long, Auto>();
    }
}
