using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem2
{
    public class Administrator : AbstractRole
    {
        [Key]
        public int Id { get; private set; }

        public Administrator(string name) : base(name) { }

        public void AddCar(CarRentalSystem system, Car car)
        {
            system.AddCar(car);
            Console.WriteLine($"Új autó hozzáadva: {car.Brand} {car.Model} (ID: {car.CarId})");
        }

        public void ModifyCarDetails(Car car, string newBrand, string newModel, int newYear, bool newAvailability)
        {
            car.SetAvailability(newAvailability);
            Console.WriteLine($"Autó (ID: {car.CarId}) adatai módosítva: {newBrand} {newModel}, Év: {newYear}");
        }

        public void DeleteCar(CarRentalSystem system, int carId)
        {
            var car = system.GetAvailableCars().FirstOrDefault(c => c.CarId == carId);
            if (car != null)
            {
                system.RemoveCar(carId);
                Console.WriteLine($"Autó törölve: {car.Brand} {car.Model} (ID: {car.CarId})");
            }
            else
            {
                Console.WriteLine("Autó nem található.");
            }
        }

        public void SetCarMileage(Car car, int newMileage)
        {
            Console.WriteLine($"Az autó (ID: {car.CarId}) kilométeróra állása módosítva: {newMileage} km");
        }
    }

}
