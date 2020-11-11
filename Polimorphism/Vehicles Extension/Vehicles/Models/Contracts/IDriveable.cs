using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models.Contracts
{
    public interface IDriveable
    {
        void Drive(double distance);

        void DriveEmpty(double distance);
    }
}
