using System;
using DemoAPI.Data.Entities;

namespace DemoAPI.Models
{
    public class Garage
    {
        public Dictionary<long, AutoEntity> CarPark { get; set; } = new Dictionary<long, AutoEntity>();
    }
}
