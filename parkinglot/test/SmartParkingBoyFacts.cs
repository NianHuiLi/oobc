using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using parkinglot;

namespace parkinglot.test
{
    [TestClass]
    public class SmartParkingBoyFacts
    {
        [TestMethod]
        public void should_return_same_car_when_smart_parkingboy_parking_car()
        {
            var parkingLot = new ParkingLot(1);
            var smartParkingBoy = new ParkingBoy(new List<ParkingLot> { parkingLot }, ParkingBoyType.Smart);
            var car = new Car();

            var carId = smartParkingBoy.Park(car);

            Assert.AreSame(car, parkingLot.Pick(carId));
        }

        [TestMethod]
        public void should_return_same_car_when_smart_parkingboy_parking_car_then_smart_parkingboy_pick()
        {
            var smartParkingBoy = new ParkingBoy(new List<ParkingLot> { new ParkingLot(1) }, ParkingBoyType.Smart);
            var car = new Car();
            var carId = smartParkingBoy.Park(car);

            var pickedCar = smartParkingBoy.Pick(carId);

            Assert.AreSame(car, pickedCar);
        }

        [TestMethod]
        public void should_return_same_car_when_use_second_parking_lot_pick_car()
        {
            var secondParkingLot = new ParkingLot(2);
            var smartParkingBoy = new ParkingBoy(new List<ParkingLot> { new ParkingLot(2), secondParkingLot }, ParkingBoyType.Smart);
            smartParkingBoy.Park(new Car());

            Car car = new Car();
            var carId = smartParkingBoy.Park(car);

            Assert.AreSame(car, secondParkingLot.Pick(carId));
        }
    }
}
