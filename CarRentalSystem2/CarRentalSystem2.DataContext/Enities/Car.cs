using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem2
{
    public class Car
    {
        public int CarId { get; private set; }
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }
        public bool IsAvailable { get; private set; }

        public Car(int carId, string brand, string model, int year, bool isAvailable)
        {
            CarId = carId;
            Brand = brand;
            Model = model;
            Year = year;
            IsAvailable = isAvailable;
        }

        public void SetAvailability(bool availability)
        {
            IsAvailable = availability;
        }
    }

}
