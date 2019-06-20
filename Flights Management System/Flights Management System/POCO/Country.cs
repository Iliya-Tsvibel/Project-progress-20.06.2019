using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights_Management_System
{
    // This is the POCO Class
    class Country : IPoco
    {
     

       
        public long ID { get; set; }
        public string COUNTRY_NAME { get; set; }

        // Constructor without parameters
        public Country()
        {

        }

        // Constructor with parameters
        public Country(long iD, string cOUNTRY_NAME)
        {
            ID = iD;
            COUNTRY_NAME = cOUNTRY_NAME;
        }


        // Equals check
        public static bool operator ==(Country country1, Country country2)
        {
            //return EqualityComparer<Country>.Default.Equals(country1, country2);
            if (ReferenceEquals(country1, null) && ReferenceEquals(country2, null))
                return true;
            if (ReferenceEquals(country1, null) || ReferenceEquals(country2, null))
                return false;

            return (country1.ID == country2.ID);
        }

        public static bool operator !=(Country country1, Country country2)
        {
            return !(country1 == country2);
        }

        public override bool Equals(object obj)
        {
            //return Equals(obj as Country);

            if (obj == null)
                return false;
            Country co = obj as Country;
            if (co == null)
                return false;
            return ID == co.ID;
        }

        //public bool Equals(Country other)
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
