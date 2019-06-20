using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights_Management_System
{

    public class LoginToken<T> where T : IUser
    {
        public T User { get; set; }
    }
}
