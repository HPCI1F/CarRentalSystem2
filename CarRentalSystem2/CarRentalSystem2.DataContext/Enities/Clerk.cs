using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem2
{
    public class Clerk : AbstractRole
    {

        [Key]
        public int Id { get; private set; }

        public Clerk(string name) : base(name) { }

        public void ApproveRental(Rental rental)
        {
            rental.Approve();
        }

        public void ConfirmCarHandOver(Rental rental)
        {
            Console.WriteLine($"Az autó (ID: {rental.Car.CarId}) átadásra került a felhasználónak.");
        }

        public void ConfirmCarReturn(Rental rental)
        {
            Console.WriteLine($"Az autó (ID: {rental.Car.CarId}) visszavétele megtörtént.");
        }

        public void ViewAllRentals(RentalsContainer rentals)
        {
            var allRentals = rentals.GetAllRentals();
            foreach (var rental in allRentals)
            {
                Console.WriteLine($"Rental ID: {rental.RentalId}, Car ID: {rental.Car.CarId}, User: {rental.User.Name}");
            }
        }

        public void IssueInvoice(Rental rental)
        {
            Console.WriteLine($"Számla kiállítva a felhasználónak ({rental.User.Name}) a kölcsönzésért.");
        }
    }

}
