using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights_Management_System
{
    class Flight : IPoco
    {
  

        // This is the POCO Class
        public long ID { get; set; }
        public long AIRLINECOMPANY_ID { get; set; }
        public long ORIGIN_COUNTRY_CODE { get; set; }
        public long DESTINATION_COUNTRY_CODE { get; set; }
        public System.DateTime DEPARTURE_TIME { get; set; }
        public System.DateTime LANDING_TIME { get; set; }
        public int REMAINING_TICKETS { get; set; }
        public int Inventory { get; internal set; }

        // Constructor without parameters
        public Flight()
        {
           
        }

        // Constructor with parameters
        public Flight(long iD, long aIRLINECOMPANY_ID, long oRIGIN_COUNTRY_CODE, long dESTINATION_COUNTRY_CODE, DateTime dEPARTURE_TIME, DateTime lANDING_TIME, int rEMAINING_TICKETS)
        {
            ID = iD;
            AIRLINECOMPANY_ID = aIRLINECOMPANY_ID;
            ORIGIN_COUNTRY_CODE = oRIGIN_COUNTRY_CODE;
            DESTINATION_COUNTRY_CODE = dESTINATION_COUNTRY_CODE;
            DEPARTURE_TIME = dEPARTURE_TIME;
            LANDING_TIME = lANDING_TIME;
            REMAINING_TICKETS = rEMAINING_TICKETS;
        }

    

        // Equals check
        public static bool operator ==(Flight flight1, Flight flight2)
        {
            //return EqualityComparer<Flight>.Default.Equals(flight1, flight2);
          
            if (ReferenceEquals(flight1, null) && ReferenceEquals(flight2, null))
                return true;
            if (ReferenceEquals(flight1, null) || ReferenceEquals(flight2, null))
                return false;

            return (flight1.ID == flight2.ID);
        }

        public static bool operator !=(Flight flight1, Flight flight2)
        {
            return !(flight1 == flight2);
        }

        public override bool Equals(object obj)
        {
            //return Equals(obj as Flight);
            if (obj == null)
                return false;
            Flight f = obj as Flight;
            if (f == null)
                return false;
            return ID == f.ID;
        }

        //public bool Equals(Flight other)
        //{
        //    return other != null &&
        //           ID == other.ID;
        //}

        //Hash Code override
        public override int GetHashCode()
        {
            return Convert.ToInt32(this.ID);
        }

    }
}
