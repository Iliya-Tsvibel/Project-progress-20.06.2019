using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights_Management_System
{
    class Customer : IPoco, IUser
    {
    

        // This is the POCO Class
        public long ID { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string USER_NAME { get; set; }
        public string PASSWORD { get; set; }
        public string ADDRESS { get; set; }
        public string PHONE_NO { get; set; }
        public string CREDIT_CARD_NUMBER { get; set; }

        // Constructor without parameters
        public Customer()
        {

        }
        // Constructor with parameters
        public Customer(long iD, string fIRST_NAME, string lAST_NAME, string uSER_NAME, string pASSWORD, string aDDRESS, string pHONE_NO, string cREDIT_CARD_NUMBER)
        {
            ID = iD;
            FIRST_NAME = fIRST_NAME;
            LAST_NAME = lAST_NAME;
            USER_NAME = uSER_NAME;
            PASSWORD = pASSWORD;
            ADDRESS = aDDRESS;
            PHONE_NO = pHONE_NO;
            CREDIT_CARD_NUMBER = cREDIT_CARD_NUMBER;
        }

        // Constructor with login parameters
        public Customer(string uSER_NAME, string pASSWORD)
        {
          
            USER_NAME = uSER_NAME;
            PASSWORD = pASSWORD;
           
        }


        public bool Equals(Customer other)
        {
            return other != null &&
                   ID == other.ID;
        }

     

        // Equals check
        public static bool operator ==(Customer customer1, Customer customer2)
        {
            //return EqualityComparer<Customer>.Default.Equals(customer1, customer2);
            if (ReferenceEquals(customer1, null) && ReferenceEquals(customer2, null))
                return true;
            if (ReferenceEquals(customer1, null) || ReferenceEquals(customer2, null))
                return false;

            return (customer1.ID == customer2.ID);
        }

        public static bool operator !=(Customer customer1, Customer customer2)
        {
            return !(customer1 == customer2);
        }

        public override bool Equals(object obj)
        {
            //return Equals(obj as Customer);
            if (obj == null)
                return false;
            Customer cu = obj as Customer;
            if (cu == null)
                return false;
            return ID == cu.ID;
        }

        //Hash Code override
        public override int GetHashCode()
        {
            return Convert.ToInt32(this.ID);
        }


        
    }
}
