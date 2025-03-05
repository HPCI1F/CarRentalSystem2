using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem2
{
    public class RentalsContainer
    {
        [Key]
        public int Id { get; private set; }

        private List<Rental> Rentals = new List<Rental>();

        public void AddRental(Rental rental)
        {
            Rentals.Add(rental);
        }

        public List<Rental> GetAllRentals()
        {
            return Rentals;
        }
    }
}
