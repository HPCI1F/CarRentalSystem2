using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem2
{
    public class RentalHistoryContainer
    {
        [Key]
        public int Id { get; private set; }

        private Dictionary<int, Rental> Rentals = new Dictionary<int, Rental>();
        private List<RentalHistory> Histories = new List<RentalHistory>();

        public void AddHistory(RentalHistory history)
        {
            Histories.Add(history);
        }

        public List<RentalHistory> GetHistoryByCar(int carId)
        {
            return Histories.Where(h => h.Car.CarId == carId).ToList();
        }


        public void AddRental(Rental rental)
        {
            if (Rentals.ContainsKey(rental.RentalId))
            {
                throw new InvalidOperationException("A kölcsönzés már létezik.");
            }
            Rentals[rental.RentalId] = rental;
        }

        public Rental GetRentalById(int rentalId)
        {
            if (Rentals.TryGetValue(rentalId, out var rental))
            {
                return rental;
            }
            throw new KeyNotFoundException("A kölcsönzés nem található.");
        }

        public List<Rental> GetAllRentals()
        {
            return Rentals.Values.ToList();
        }


    }
}
