using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalSystem2;

namespace CarRentalSystem2.Sevices
{
    public interface iRentalService
    {
        public void RentCar();
        public void ReturnCar();
    }
    public class RentalService : iRentalService
    {
        public void RentCar()
        {
            Console.WriteLine("Car rented");
        }
        public void ReturnCar()
        {
            Console.WriteLine("Car returned");
        }
    }
    
}
