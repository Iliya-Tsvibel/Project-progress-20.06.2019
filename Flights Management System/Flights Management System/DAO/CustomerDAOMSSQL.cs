using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights_Management_System.DAO
{
    class CustomerDAOMSSQL : ICustomerDAO
    {

        private bool DoesCustomerExist(Customer t)
        {
            if (t.USER_NAME == null || t.PASSWORD == null)
            {
                throw new InsufficientDataException();
            }

            int result;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDBConnection"].ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "DOES_USER_EXIST";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter usernameParameter = new SqlParameter();
                usernameParameter.SqlDbType = SqlDbType.VarChar;
                usernameParameter.SqlValue = t.USER_NAME;
                usernameParameter.ParameterName = "@USERNAME";

                SqlParameter returnParameter = new SqlParameter();
                returnParameter.SqlDbType = SqlDbType.Int;
                returnParameter.Direction = ParameterDirection.Output;
                returnParameter.ParameterName = "@RETURN";

                sqlCommand.Parameters.Add(usernameParameter);
                sqlCommand.Parameters.Add(returnParameter);

                connection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                result = (int)returnParameter.Value;
                connection.Close();
            }

            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Add(Customer t)
        {
            if (DoesCustomerExist(t))
            {
                throw new CustomerAlreadyExistsException();
            }

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDBConnection"].ConnectionString))
            {

                SqlCommand AddnewUser = new SqlCommand();
                AddnewUser.Connection = connection;
                AddnewUser.CommandText = "ADD_NEW_CUSTOMER";
                AddnewUser.CommandType = CommandType.StoredProcedure;

                SqlParameter username = new SqlParameter();
                username.SqlDbType = SqlDbType.VarChar;
                username.Value = t.USER_NAME;
                username.ParameterName = "@USERNAME";
                AddnewUser.Parameters.Add(username);

                SqlParameter password = new SqlParameter();
                password.SqlDbType = SqlDbType.VarChar;
                password.Value = t.PASSWORD;
                password.ParameterName = "@PASSWORD";
                AddnewUser.Parameters.Add(password);

                SqlParameter firstName = new SqlParameter();
                firstName.SqlDbType = SqlDbType.VarChar;
                firstName.Value = t.FIRST_NAME;
                firstName.ParameterName = "@FIRSTNAME";
                AddnewUser.Parameters.Add(firstName);

                SqlParameter lastName = new SqlParameter();
                lastName.SqlDbType = SqlDbType.VarChar;
                lastName.Value = t.LAST_NAME;
                lastName.ParameterName = "@LASTNAME";
                AddnewUser.Parameters.Add(lastName);

                SqlParameter phnonenoNumber = new SqlParameter();
                phnonenoNumber.SqlDbType = SqlDbType.Int;
                phnonenoNumber.Value = t.PHONE_NO;
                phnonenoNumber.ParameterName = "@PHONENUMBER";
                AddnewUser.Parameters.Add(phnonenoNumber);

                SqlParameter idNumber = new SqlParameter();
                idNumber.SqlDbType = SqlDbType.Int;
                idNumber.Value = t.ID;
                idNumber.ParameterName = "@ID";
                AddnewUser.Parameters.Add(idNumber);

                SqlParameter addressNumber = new SqlParameter();
                addressNumber.SqlDbType = SqlDbType.Int;
                addressNumber.Value = t.ADDRESS;
                addressNumber.ParameterName = "@ADDRESS";
                AddnewUser.Parameters.Add(addressNumber);

                connection.Open();
                AddnewUser.ExecuteNonQuery();
                connection.Close();
            }
        }

        internal static void CustomerLogin(Customer name)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerByUserame(string name)
        {
            // sql query: select from Airline where name='{name}'
            // if found
            return new Customer();
            // if not:
            //return null;
        }

        public void Remove(Customer t)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer t)
        {
            throw new NotImplementedException();
        }

       
    }
}
