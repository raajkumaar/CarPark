using Raaj.CarPark.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raaj.CarPark.BusinessLogic
{
    public class OverweightChargesCalculator : IExtraChargesCalculator
    {
        // New fees could be added to the system.
        // Class must be closed for modification and open for extension.
        // Hence, the method is made virtual
        public virtual void CalculateExtraCharges(Vehicle vehicle)
        {
            CalculateOverweightCharges(vehicle);
        }

        private void CalculateOverweightCharges(Vehicle vehicle)
        {
            // An extra charge of $3 is added to a vehicle fee if its weight is over 100kg.
            if (vehicle.Weight > 100)
                vehicle.OutstandingFee = vehicle.OutstandingFee + 3;
        }
    }
}
