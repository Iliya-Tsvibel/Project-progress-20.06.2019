using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights_Management_System
{
    class Administrator : IUser
    {

        public long ID { get; set; }
        public string USER_NAME { get; set; }
        public string PASSWORD { get; set; }

        // Constructor without parameters
        public Administrator()
        {
           
        }
        // Constructor with parameters
        public Administrator(long iD, string uSER_NAME, string pASSWORD)
        {
            ID = iD;
            USER_NAME = uSER_NAME;
            PASSWORD = pASSWORD;
        }

        // Constructor with login parameters
        public Administrator(string uSER_NAME, string pASSWORD)
        {
            USER_NAME = uSER_NAME;
            PASSWORD = pASSWORD;
        }

        
    }
}
