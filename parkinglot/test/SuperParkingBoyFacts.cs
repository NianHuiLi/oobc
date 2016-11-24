using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using parkinglot;

namespace parkinglot.test
{
    [TestClass]
    public class SuperParkingBoyFacts
    {
        [TestMethod]
        public void should_return_same_car_when_super_parkingboy_parking_car()
        {
            var parkingLot = new ParkingLot(1);
            var superParkingBoy = new ParkingBoy(new List<ParkingLot> { parkingLot}, ParkingBoyType.Super);
            var car = new Car();

            var carId = superParkingBoy.Park(car);

            Assert.AreSame(car, parkingLot.Pick(carId));
        }

        [TestMethod]
        public void should_return_same_car_when_super_parkingboy_parking_car_then_super_parkingboy_pick()
        {
            var superParkingBoy = new ParkingBoy(new List<ParkingLot> { new ParkingLot(1)}, ParkingBoyType.Super);
            var car = new Car();
            var carId = superParkingBoy.Park(car);

            var pickedCar = superParkingBoy.Pick(carId);

            Assert.AreSame(car, pickedCar);
        }

        [TestMethod]
        public void should_return_same_car_when_super_parkingboy_parking_car_()
        {
            var firstParkingLot = new ParkingLot(2);
            var secondParkingLot = new ParkingLot(2);
            var superParkingBoy = new ParkingBoy(new List<ParkingLot> { firstParkingLot,secondParkingLot}, ParkingBoyType.Super);
            firstParkingLot.Park(new Car());

            Car car =new Car();
            var carId = superParkingBoy.Park(car);

            Assert.AreSame(car, secondParkingLot.Pick(carId));
        }
    }
}
