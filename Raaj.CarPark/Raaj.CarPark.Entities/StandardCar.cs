using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raaj.CarPark.Entities
{
    public class StandardCar : Vehicle
    {
        public StandardCar()
        {
            // Standard Car: Fee is calculated as vehicle fee + $5
            OutstandingFee = OutstandingFee + 5;
        }

        public override string ToString()
        {
            return base.ToString() + "STANDARD CAR ";
        }
    }
}
