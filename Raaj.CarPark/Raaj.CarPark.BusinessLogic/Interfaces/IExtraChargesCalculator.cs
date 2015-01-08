using Raaj.CarPark.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raaj.CarPark.BusinessLogic
{
    public interface IExtraChargesCalculator
    {
        void CalculateExtraCharges(Vehicle vehicle);
    }
}
