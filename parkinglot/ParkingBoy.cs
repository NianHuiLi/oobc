using System;
using System.Collections.Generic;
using System.Linq;

namespace parkinglot
{
    public class ParkingBoy
    {

        private readonly List<ParkingLot> _parkingLots;
        private readonly ParkingBoyType _parkingBoyType;

        public ParkingBoy(List<ParkingLot> parkingLots, ParkingBoyType parkingBoyType = ParkingBoyType.None)
        {
            _parkingLots = parkingLots;
            _parkingBoyType = parkingBoyType;
        }

        public Guid Park(Car car)
        {
            return FindParkingLot()?.Park(car) ?? Guid.Empty;
        }

        private ParkingLot FindParkingLot()
        {
            Func<ParkingLot, double> orderBy = parkinglot => 1;

            switch (_parkingBoyType)
            {
                case ParkingBoyType.Smart:
                     orderBy = parkinglot => parkinglot.Remainder;
                    break;
                    
                case ParkingBoyType.Super:
                    orderBy = parkinglot => parkinglot.VacancyRate;
                    break;
            }

            return _parkingLots
                .Where(parkinglot => !parkinglot.IsFull)
                .OrderByDescending(orderBy)
                .FirstOrDefault();
        }

        public Car Pick(Guid carId)
        {
            return _parkingLots.First(parkinglot => parkinglot.HasCar(carId))?.Pick(carId);
        }
    }
}