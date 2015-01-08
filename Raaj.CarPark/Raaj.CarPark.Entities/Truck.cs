using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raaj.CarPark.Entities
{
    public class Truck : Vehicle
    {
        public Truck()
        {
            // Truck: Fee is calculated as vehicle fee + $10.
            OutstandingFee = OutstandingFee + 10;
        }

        public override string ToString()
        {
            return base.ToString() + "TRUCK ";
        }
    }
}
