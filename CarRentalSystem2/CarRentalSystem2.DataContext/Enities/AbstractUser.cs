using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem2
{
    public abstract class AbstractUser
    {
        [Key]
        public int Id { get; private set; }

        public string Name { get; protected set; }
        public string Address { get; protected set; }
        public string PhoneNumber { get; protected set; }

        protected AbstractUser(string name, string address, string phoneNumber)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
        }
    }
}
