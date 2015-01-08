using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raaj.CarPark.Entities
{
    public class LuxuryCar : StandardCar
    {
        public LuxuryCar()
        {
            // Luxury Car: Fee is calculated as standard car fee + $3
            OutstandingFee = OutstandingFee + 3;
        }

        public override string ToString()
        {
            return base.ToString().Replace("STANDARD", "LUXURY");
        }
    }
}
