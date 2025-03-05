using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem2
{
    public class NonRegisteredUser : AbstractUser
    {
        public NonRegisteredUser(string name, string address, string phoneNumber)
            : base(name, address, phoneNumber)
        {
        }
    }

}
