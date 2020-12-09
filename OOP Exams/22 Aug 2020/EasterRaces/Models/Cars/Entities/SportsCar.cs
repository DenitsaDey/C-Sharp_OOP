using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const int MaxHorsePower = 450;
        private const int MinHorsePower = 250;
        public SportsCar(string model, int horsePower) 
            : base(model, horsePower, 3000, MinHorsePower, MaxHorsePower)
        {
        }
    }
}
