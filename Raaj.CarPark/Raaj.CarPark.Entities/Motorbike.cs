using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raaj.CarPark.Entities
{
    public  class Motorbike : Vehicle
    {
        public Motorbike()
        {
            // Motorbike: Fee is calculated as vehicle fee + $2.
            OutstandingFee = OutstandingFee + 2;
        }

        public override string ToString()
        {
            return base.ToString() + "MOTORBIKE ";
        }
    }
}
