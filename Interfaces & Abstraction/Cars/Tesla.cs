using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : Car, IElectricCar
    {
        public int Battery { get; private set; }

        public Tesla(string model, string color, int battery)
            :base(model, color)
        {
            this.Battery = battery;
        }
       

        public override string ToString()
        {
            return $"{this.Color} {this.GetType().Name} {this.Model} with {this.Battery} Batteries";
        }
    }
}
