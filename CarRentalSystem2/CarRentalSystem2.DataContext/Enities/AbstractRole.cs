using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem2
{
    public abstract class AbstractRole
    {
        public string Name { get; private set; }

        protected AbstractRole(string name)
        {
            Name = name;
        }
    }

}
