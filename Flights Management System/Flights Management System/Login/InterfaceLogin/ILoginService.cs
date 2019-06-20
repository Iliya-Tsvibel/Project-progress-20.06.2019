using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights_Management_System
{
    interface ILoginService
    {
        //void TryAdminLogin();
        //void TryAirlineLogin();
        //void TryCustomerLogin();

        bool TryAdminLogin(string userName, string password, out LoginToken<Administrator> token);
        bool TryCustomerLogin(string userName, string password, out LoginToken<Customer> token);
        bool TryAirlineLogin(string userName, string password, out LoginToken<AirlineCompany> token);
    }
}
