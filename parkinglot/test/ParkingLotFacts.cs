using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace parkinglot.test
{
    [TestClass]
    public class ParkingLotFacts
    {
        [TestMethod]
        public void should_return_picked_car_same_with_parked_car()
        {
            var parkingLot = new ParkingLot(1);
            var car = new Car();
            var carId = parkingLot.Park(car);

            Assert.AreSame(car, parkingLot.Pick(carId));
        }

        [TestMethod]
        public void should_return_picked_first_car_with_parked_two_car_when_pick_first_car()
        {
            var parkingLot = new ParkingLot(2);
            var firstCar = new Car();
            var firstCarId = parkingLot.Park(firstCar);
            parkingLot.Park(new Car());

            Assert.AreSame(firstCar, parkingLot.Pick(firstCarId));
        }

        [TestMethod]
        public void should_return_picked_second_car_with_parked_two_car_when_pick_second_car()
        {
            var parkingLot = new ParkingLot(2);
            parkingLot.Park(new Car());
            var secondCar = new Car();
            var secondCarId = parkingLot.Park(secondCar);

            Assert.AreSame(secondCar, parkingLot.Pick(secondCarId));
        }

        [TestMethod]
        public void should_return_null_when_pick_same_car_twice()
        {
            var parkingLot = new ParkingLot(1);
            var car = new Car();
            var carId = parkingLot.Park(car);

            Assert.AreSame(car, parkingLot.Pick(carId));
            Assert.IsNull(parkingLot.Pick(carId));
        }

        [TestMethod]
        public void should_return_null_when_use_invalid_car_id()
        {
            var parkingLot = new ParkingLot(1);
            var car = new Car();
            parkingLot.Park(car);

            Assert.IsNull(parkingLot.Pick(Guid.Empty));
        }

        [TestMethod]
        public void should_can_not_pack_when_parkinglot_is_full()
        {
            var parkingLot = new ParkingLot(1);
            var car = new Car();
            parkingLot.Park(car);

            Assert.AreEqual(Guid.Empty,parkingLot.Park(car));
        }

        [TestMethod]
        public void should_can_pack_one_car_when_pick_one_car_in_full_parkinglot()
        {
            var parkingLot =new ParkingLot(1);
            var carId= parkingLot.Park(new Car());
            parkingLot.Pick(carId);

            Assert.AreNotEqual(Guid.Empty, parkingLot.Park(new Car()));
        }
    }
}
