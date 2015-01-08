using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raaj.CarPark.Entities
{
    public abstract class BaseCarPark
    {
        public string Name { get; set; }
        public int Bays { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public float OccupiedPercentage 
        {
            get 
            {
                return (((float)Occupancy / Bays) * 100);
            }
        }

        public int Occupancy 
        {
            get
            {
                return Vehicles.Count;
            }
        }

        protected abstract void EnterCarParkValidation();
        protected abstract void ExitCarParkValidation(Vehicle vehicle);
        public abstract void EnterCarPark(Vehicle vehicle);
        public abstract void ExitCarPark(Vehicle vehicle);

        public BaseCarPark()
        {
            Vehicles = new List<Vehicle>();
        }
    }

   
}
