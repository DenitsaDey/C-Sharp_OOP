using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Common
{
    public static class ExceptionMessages
    {
        public static string NotEnoughFuelExcMsg = "{0} needs refueling";
        public static string InvalidTypeExcMsg = "Invalid vehicle type";
        public static string NegativeFuelExcMsg = "Fuel must be a positive number";
        public static string MoreFuelExcMsg = "Cannot fit {0} fuel in the tank";
    }
}
