using System;
using System.Collections.Generic;

namespace parkinglot
{
    public class ParkingLot
    {
        private readonly int _size;
        private readonly List<Car> _cars;

        public ParkingLot(int size)
        {
            this._size = size;
            this._cars = new List<Car>(this._size);
        }

        public Guid Park(Car car)
        {
            if (IsFull)
            {
                return Guid.Empty;
            }
            _cars.Add(car);
            return car.Id;
        }

        public bool IsFull => Remainder == 0;

        public int Remainder => this._size - this._cars.Count;

        public double VacancyRate => this.Remainder / (double)this._size;

        public Car Pick(Guid carId)
        {
            var car = FindCar(carId);
            if (car != null)
            {
                _cars.Remove(car);
            }
            return car;
        }

        public bool HasCar(Guid carId)
        {
            return FindCar(carId) != null;
        }

        private Car FindCar(Guid carId)
        {
            return _cars.Find(car => car.Id == carId);
        }
    }
}