﻿namespace DemoAPI.Models
{
    public class Warehouse
    {
        public Dictionary<long, Item> Stock { get; set; } = [];

    }
}