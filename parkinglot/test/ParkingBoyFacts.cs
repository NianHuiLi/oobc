using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using parkinglot;

namespace parkinglot.test
{
    [TestClass]
    public class ParkingBoyFacts
    {
        [TestMethod]
        public void should_can_park_one_car_with_parking_boy()
        {
            var parkingLot = new ParkingLot(1);
            var parkingBoy = new ParkingBoy(new List<ParkingLot> {parkingLot});
            var car = new Car();

            var carId = parkingBoy.Park(car);

            Assert.AreSame(car, parkingLot.Pick(carId));
        }

        [TestMethod]
        public void should_can_pick_one_car_with_parking_boy()
        {
            var parkingLot = new ParkingLot(1);
            var parkingBoy = new ParkingBoy(new List<ParkingLot> {parkingLot});
            var car = new Car();

            var carId = parkingBoy.Park(car);

            Assert.AreSame(car, parkingBoy.Pick(carId));
        }

        [TestMethod]
        public void should_can_pick_one_car_with_parking_boy_packed_and_pakinglot_pick()
        {
            var firstParkingLot = new ParkingLot(1);
            var parkingBoy = new ParkingBoy(new List<ParkingLot> { firstParkingLot, new ParkingLot(1) });
            var car = new Car();

            var carId = parkingBoy.Park(car);

            Assert.AreSame(car, firstParkingLot.Pick(carId));
        }

        [TestMethod]
        public void should_can_pack_one_car_when_parking_boy_has_one_full_packinglot_and_unfull_packinglot()
        {
            var secondParkingLot = new ParkingLot(1);
            var parkingBoy = new ParkingBoy(new List<ParkingLot> { new ParkingLot(1), secondParkingLot });
            parkingBoy.Park(new Car());

            var car = new Car();
            var carId = parkingBoy.Park(car);

            Assert.AreSame(car, secondParkingLot.Pick(carId));
        }
        
    }
}
