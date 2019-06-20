using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights_Management_System
{
    // This is the POCO Class
    public class AirlineCompany : IPoco, IUser
    {
       

        public long ID { get; set; }
        public string AIRLINE_NAME { get; set; }
        public string USER_NAME { get; set; }
        public string PASSWORD { get; set; }
        public long COUNTRY_CODE { get; set; }



        // Constructor without parameters
        public AirlineCompany()
        {
           
        }

        // Constructor with parameters
        public AirlineCompany(long iD, string aIRLINE_NAME, string uSER_NAME, string pASSWORD, long cOUNTRY_CODE)
        {
            ID = iD;
            AIRLINE_NAME = aIRLINE_NAME;
            USER_NAME = uSER_NAME;
            PASSWORD = pASSWORD;
            COUNTRY_CODE = cOUNTRY_CODE;
        }

        // Constructor with login parameters
        public AirlineCompany(string uSER_NAME, string pASSWORD)
        {
           
            USER_NAME = uSER_NAME;
            PASSWORD = pASSWORD;
            
        }



        public static bool operator ==(AirlineCompany company1, AirlineCompany company2)
        {
            //return EqualityComparer<AirlineCompany>.Default.Equals(company1, company2);
            if (ReferenceEquals(company1, null) && ReferenceEquals(company2, null))
                return true;
            if (ReferenceEquals(company1, null) || ReferenceEquals(company2, null))
                return false;

            return (company1.ID == company2.ID);
        }

        public static bool operator !=(AirlineCompany company1, AirlineCompany company2)
        {
            return !(company1 == company2);
        }

        // Equals check
        public override bool Equals(object obj)
        {
            //return Equals(obj as AirlineCompany);

            if (obj == null)
                return false;
            AirlineCompany a = obj as AirlineCompany;
            if (a == null)
                return false;
            return ID == a.ID;
        }

        //public bool Equals(AirlineCompany other)
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
