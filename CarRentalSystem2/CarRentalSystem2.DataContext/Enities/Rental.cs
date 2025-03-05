using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem2
{
    public class Rental
    {
        public int RentalId { get; private set; }
        public Car Car { get; private set; }
        public AbstractUser User { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool IsApproved { get; private set; }

        private Rental() { }

        public Rental(int rentalId, Car car, AbstractUser user, DateTime startDate, DateTime endDate)
        {
            RentalId = rentalId;
            Car = car;
            User = user;
            StartDate = startDate;
            EndDate = endDate;
            IsApproved = false;
        }

        public void Approve()
        {
            IsApproved = true;
            Car.SetAvailability(false);
        }
    }

}
