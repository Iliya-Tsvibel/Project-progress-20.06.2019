using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights_Management_System
{
    class Ticket : IPoco
    {
      

        // This is the POCO Class
        public long ID { get; set; }
        public long FLIGHT_ID { get; set; }
        public long CUSTOMER_ID { get; set; }

        // Constructor without parameters
        public Ticket()
        {
           
        }

        // Constructor with parameters
        public Ticket(long iD, long fLIGHT_ID, long cUSTOMER_ID)
        {
            ID = iD;
            FLIGHT_ID = fLIGHT_ID;
            CUSTOMER_ID = cUSTOMER_ID;
        }

       

        // Equals check
        public static bool operator ==(Ticket ticket1, Ticket ticket2)
        {
            //return EqualityComparer<Ticket>.Default.Equals(ticket1, ticket2);
            if (ReferenceEquals(ticket1, null) && ReferenceEquals(ticket2, null))
                return true;
            if (ReferenceEquals(ticket1, null) || ReferenceEquals(ticket2, null))
                return false;
            return (ticket1.ID == ticket2.ID);
        }

        public static bool operator !=(Ticket ticket1, Ticket ticket2)
        {
            return !(ticket1 == ticket2);
        }

        public override bool Equals(object obj)
        {
            //return Equals(obj as Ticket);
            if (obj == null)
                return false;
            Ticket t = obj as Ticket;
            if (t == null)
                return false;
            return ID == t.ID;
        }

        public bool Equals(Ticket other)
        {
            return other != null &&
                   ID == other.ID;
        }

        //Hash Code override
        public override int GetHashCode()
        {
            return Convert.ToInt32(this.ID);
        }
    }
}
