using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Raaj.CarPark.Entities;
using Raaj.CarPark.BusinessLogic;

namespace Raaj.CarPark.Tests
{
    [TestClass]
    public class CarParkTests
    {
        BaseCarPark carPark;
        IExtraChargesCalculator extraChargesCalculator;
        [TestInitialize]
        public void Init()
        {
            carPark = new TestCarPark();
            carPark.Bays = 10;
            extraChargesCalculator = new OverweightChargesCalculator();
            carPark.EnterCarPark(new StandardCar() { Id = 1, Weight = 60 });
            carPark.EnterCarPark(new LuxuryCar() { Id = 2, Weight = 80 });
            carPark.EnterCarPark(new Motorbike() { Id = 3, Weight = 40 });
            carPark.EnterCarPark(new Truck() { Id = 4, Weight = 101 });
            carPark.Vehicles.ForEach(v => extraChargesCalculator.CalculateExtraCharges(v));
        }

        [TestMethod]
        public void CarParkStep3Test()
        {
            Assert.AreEqual(4, carPark.Occupancy);
            Assert.AreEqual("Test carpark", carPark.Name);
            Assert.AreEqual(40, carPark.OccupiedPercentage);
            Assert.AreEqual(7, carPark.Vehicles.Where(v => v.Id == 1).Single().OutstandingFee);
            Assert.AreEqual(10, carPark.Vehicles.Where(v => v.Id == 2).Single().OutstandingFee);
            Assert.AreEqual(4, carPark.Vehicles.Where(v => v.Id == 3).Single().OutstandingFee);
            Assert.AreEqual(15, carPark.Vehicles.Where(v => v.Id == 4).Single().OutstandingFee);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CarParkEntryValidationErrorTest()
        {
            carPark.Bays = 4;
            carPark.EnterCarPark(new Truck() { Id = 5, Weight = 101 });
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CarParkExitValidationErrorTest()
        {
           carPark.ExitCarPark(carPark.Vehicles.Where(v => v.Id == 4).Single());
        }

        [TestMethod]
        public void CarParkExitTest()
        {
            var vehicle = carPark.Vehicles.Where(v => v.Id == 4).Single();
            vehicle.PayFee();
            carPark.ExitCarPark(vehicle);
        }
    }
}
