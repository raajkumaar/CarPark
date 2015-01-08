using Raaj.CarPark.BusinessLogic;
using Raaj.CarPark.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raaj.CarPark
{
    public class EventsProcessor
    {
        public BaseCarPark CarPark { get; set; }
        public IExtraChargesCalculator ExtraChargesCalculator { get; set; }

        // 1. Initialise the car park with 10 bays and a name of “Test carpark”
        public void Step1()
        {
            CarPark = new TestCarPark();
            CarPark.Bays = 10;
            ExtraChargesCalculator = new OverweightChargesCalculator();
        }

        //2. Have one of each type of vehicles enter the car park. 
        //The truck should have a weight of 101 kg.

        public void Step2()
        {
            CarPark.EnterCarPark(new StandardCar() { Id = 1, Weight = 60 });
            CarPark.EnterCarPark(new LuxuryCar() { Id = 2, Weight = 80 });
            CarPark.EnterCarPark(new Motorbike() { Id = 3, Weight = 40 });
            CarPark.EnterCarPark(new Truck() { Id = 4, Weight = 101 });
            CarPark.Vehicles.ForEach(v => ExtraChargesCalculator.CalculateExtraCharges(v));
        }

        //4. Pay the outstanding fee for the luxury car
        public void Step4()
        {
            var luxuryCar = CarPark.Vehicles.Where(v => v.Id == 2).Single();
            luxuryCar.PayFee();
        }

        //6. Have the luxury car exit the car park
        public void Step6()
        {
            var luxuryCar = CarPark.Vehicles.Where(v => v.Id == 2).Single();
            CarPark.ExitCarPark(luxuryCar);
        }

        //8. Pay the outstanding fees for the remaining cars
        public void Step8()
        {
            var standardCar = CarPark.Vehicles.Where(v => v.Id == 1).Single();
            standardCar.PayFee();
        }

        //9. Have the remaining cars exit the car park
        public void Step9()
        {
            var standardCar = CarPark.Vehicles.Where(v => v.Id == 1).Single();
            CarPark.ExitCarPark(standardCar);
        }

        //11. Have a motorbike enter the car park
        public void Step11()
        {
            var newBike = new Motorbike() { Id = 5, Weight = 140 };
            ExtraChargesCalculator.CalculateExtraCharges(newBike);
            CarPark.EnterCarPark(newBike);
        }

        //12. Have the motorbike exit the car park
        public void Step12()
        {
            var motorbike = CarPark.Vehicles.Where(v => v.Id == 5).Single();
            CarPark.ExitCarPark(motorbike);
        }
    }
}
