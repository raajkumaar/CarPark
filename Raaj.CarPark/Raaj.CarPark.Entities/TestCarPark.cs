using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raaj.CarPark.Entities
{
    public class TestCarPark : BaseCarPark
    {
        public TestCarPark()
        {
            Name = "Test carpark";
        }

        protected override void EnterCarParkValidation()
        {
            if (Bays == Occupancy)
                throw new InvalidOperationException
                    ("A vehicle cannot enter the car park if it is full.");
        }

        protected override void ExitCarParkValidation(Vehicle vehicle)
        {
            if (!vehicle.IsFeePaid)
                throw new InvalidOperationException
                    ("A vehicle cannot exit the car park if its fee has not been paid.");
        }

        public override void EnterCarPark(Vehicle vehicle)
        {
            EnterCarParkValidation();
            Vehicles.Add(vehicle);
        }

        public override void ExitCarPark(Vehicle vehicle)
        {
            ExitCarParkValidation(vehicle);
            Vehicles.Remove(vehicle);
        }
    }
}
