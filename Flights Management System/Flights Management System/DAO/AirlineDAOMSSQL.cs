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
    class AirlineDAOMSSQL : IAirlineDAO
    {

        private bool DoesAirlineCompanyExist(AirlineCompany t)
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
                sqlCommand.CommandText = "DOES_AIRLINECOMPANY_EXIST";
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

        internal static void AirlineLogin(AirlineCompany company)
        {
            throw new NotImplementedException();
        }

        public void Add(AirlineCompany t)
        {
            if (DoesAirlineCompanyExist(t))
            {
                throw new AirlineCompanyAlreadyExistsException();
            }

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDBConnection"].ConnectionString))
            {

                SqlCommand addNewAirlineCompany = new SqlCommand();
                addNewAirlineCompany.Connection = connection;
                addNewAirlineCompany.CommandText = "ADD_NEW_AIRLINE_COMPANY";
                addNewAirlineCompany.CommandType = CommandType.StoredProcedure;

                SqlParameter companynameParameter = new SqlParameter();
                companynameParameter.SqlDbType = SqlDbType.VarChar;
                companynameParameter.Value = t.AIRLINE_NAME;
                companynameParameter.ParameterName = "@AIRLINE_NAME";
                addNewAirlineCompany.Parameters.Add(companynameParameter);

                SqlParameter passwordParameter = new SqlParameter();
                passwordParameter.SqlDbType = SqlDbType.VarChar;
                passwordParameter.Value = t.PASSWORD;
                passwordParameter.ParameterName = "@PASSWORD";
                addNewAirlineCompany.Parameters.Add(passwordParameter);

                SqlParameter usernameParameter = new SqlParameter();
                usernameParameter.SqlDbType = SqlDbType.VarChar;
                usernameParameter.Value = t.USER_NAME;
                usernameParameter.ParameterName = "@USERNAME";
                addNewAirlineCompany.Parameters.Add(usernameParameter);

                SqlParameter countryidParameter = new SqlParameter();
                countryidParameter.SqlDbType = SqlDbType.VarChar;
                countryidParameter.Value = t.COUNTRY_CODE;
                countryidParameter.ParameterName = "@COUNTRY_CODE";
                addNewAirlineCompany.Parameters.Add(countryidParameter);

                SqlParameter idParameter = new SqlParameter();
                idParameter.SqlDbType = SqlDbType.VarChar;
                idParameter.Value = t.ID;
                idParameter.ParameterName = "@ID";
                addNewAirlineCompany.Parameters.Add(idParameter);

                connection.Open();
                addNewAirlineCompany.ExecuteNonQuery();
                connection.Close();
            }
        }

       
        public AirlineCompany Get(int id)
        {
            throw new NotImplementedException();
        }

        public AirlineCompany GetAirlineByUserame(string name)
        {
            // sql query: select from Airline where name='{name}'
            // if found
            return new AirlineCompany();
            // if not:
            //return null;
        }

        public IList<AirlineCompany> GetAll()
        {
            throw new NotImplementedException();
        }

        public IList<AirlineCompany> GetAllAirlinesByCountry(int countryId)
        {
            throw new NotImplementedException();
        }

        public void Remove(AirlineCompany t)
        {
            throw new NotImplementedException();
        }

        public void Update(AirlineCompany t)
        {
            throw new NotImplementedException();
        }
    }
}
