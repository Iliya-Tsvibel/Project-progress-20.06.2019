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
    class FlightDAOMSSQL : IFightDAO
    {

        private bool DoesFlightExistByID(long flightID)
        {
            int result;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDBConnection"].ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "DOES_FLIGHT_EXIST_BY_ID";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter flightIDParameter = new SqlParameter();
                flightIDParameter.SqlDbType = SqlDbType.VarChar;
                flightIDParameter.SqlValue = flightID;
                flightIDParameter.ParameterName = "@FLIGHTID";

                SqlParameter returnParameter = new SqlParameter();
                returnParameter.SqlDbType = SqlDbType.Int;
                returnParameter.Direction = ParameterDirection.Output;
                returnParameter.ParameterName = "@RETURN";

                sqlCommand.Parameters.Add(flightIDParameter);
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

        private void UpdateInventory(Flight t)
        {
            if (!DoesAirlineIDMatch(t))
            {
                throw new ProductAlreadyExistsException();
            }
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDBConnection"].ConnectionString))
            {

                SqlCommand AddnewFlight = new SqlCommand();
                AddnewFlight.Connection = connection;
                AddnewFlight.CommandText = "UPDATE_INVENTORY";
                AddnewFlight.CommandType = CommandType.StoredProcedure;

                SqlParameter airline_id = new SqlParameter();
                airline_id.SqlDbType = SqlDbType.VarChar;
                airline_id.Value = t.ID;
                airline_id.ParameterName = "@FLIGHT_ID";
                AddnewFlight.Parameters.Add(airline_id);

                SqlParameter airline_idParameter = new SqlParameter();
                airline_id.SqlDbType = SqlDbType.Int;
                airline_id.Value = t.AIRLINECOMPANY_ID;
                airline_id.ParameterName = "@AIRLINECOMPANY_ID";
                AddnewFlight.Parameters.Add(airline_id);

                SqlParameter amountParameter = new SqlParameter();
                amountParameter.SqlDbType = SqlDbType.Int;
                amountParameter.Value = t.Inventory;
                amountParameter.ParameterName = "@AMOUNT";
                AddnewFlight.Parameters.Add(amountParameter);

                connection.Open();
                AddnewFlight.ExecuteNonQuery();
                connection.Close();
            }
        }

        private bool DoesAirlineIDMatch(Flight t)
        {
            int result;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDBConnection"].ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "DOES_FLIGHT_EXIST_BY_ID";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter flightIdParameter = new SqlParameter();
                flightIdParameter.SqlDbType = SqlDbType.Int;
                flightIdParameter.SqlValue = t.ID;
                flightIdParameter.ParameterName = "@FLIGHTID";

                SqlParameter airlineIdParameter = new SqlParameter();
                airlineIdParameter.SqlDbType = SqlDbType.Int;
                airlineIdParameter.SqlValue = t.AIRLINECOMPANY_ID;
                airlineIdParameter.ParameterName = "@AIRLINECOMPANY_ID";

                SqlParameter returnParameter = new SqlParameter();
                returnParameter.SqlDbType = SqlDbType.Int;
                returnParameter.Direction = ParameterDirection.Output;
                returnParameter.ParameterName = "@RETURN";

                sqlCommand.Parameters.Add(flightIdParameter);
                sqlCommand.Parameters.Add(airlineIdParameter);
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

        public void Add(Flight t)
        {

            if (DoesFlightExistByID(t.ID))

            {
                UpdateInventory(t);
            }


            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDBConnection"].ConnectionString))
            {

                SqlCommand AddnewFlight = new SqlCommand();
                AddnewFlight.Connection = connection;
                AddnewFlight.CommandText = "ADD_NEW_FLIGHT";
                AddnewFlight.CommandType = CommandType.StoredProcedure;

                SqlParameter idParameter = new SqlParameter();
                idParameter.SqlDbType = SqlDbType.VarChar;
                idParameter.Value = t.ID;
                idParameter.ParameterName = "@ID";
                AddnewFlight.Parameters.Add(idParameter);

                SqlParameter airlinecompany_idParameter = new SqlParameter();
                airlinecompany_idParameter.SqlDbType = SqlDbType.Int;
                airlinecompany_idParameter.Value = t.AIRLINECOMPANY_ID;
                airlinecompany_idParameter.ParameterName = "@AIRLINECOMPANY_ID";
                AddnewFlight.Parameters.Add(airlinecompany_idParameter);

                SqlParameter origin_country_codeParameter = new SqlParameter();
                origin_country_codeParameter.SqlDbType = SqlDbType.Int;
                origin_country_codeParameter.Value = t.ORIGIN_COUNTRY_CODE;
                origin_country_codeParameter.ParameterName = "@ORIGIN_COUNTRY_CODE";
                AddnewFlight.Parameters.Add(origin_country_codeParameter);

                SqlParameter destination_country_codeParameter = new SqlParameter();
                destination_country_codeParameter.SqlDbType = SqlDbType.Int;
                destination_country_codeParameter.Value = t.DESTINATION_COUNTRY_CODE;
                destination_country_codeParameter.ParameterName = "@DESTINATION_COUNTRY_CODE";
                AddnewFlight.Parameters.Add(destination_country_codeParameter);

                SqlParameter departure_timeParameter = new SqlParameter();
                departure_timeParameter.SqlDbType = SqlDbType.Int;
                departure_timeParameter.Value = t.DEPARTURE_TIME;
                departure_timeParameter.ParameterName = "@DEPARTURE_TIME";
                AddnewFlight.Parameters.Add(departure_timeParameter);

                SqlParameter landing_timeParameter = new SqlParameter();
                landing_timeParameter.SqlDbType = SqlDbType.Int;
                landing_timeParameter.Value = t.LANDING_TIME;
                landing_timeParameter.ParameterName = "@LANDING_TIME";
                AddnewFlight.Parameters.Add(landing_timeParameter);

                SqlParameter remaining_ticketsParameter = new SqlParameter();
                remaining_ticketsParameter.SqlDbType = SqlDbType.Int;
                remaining_ticketsParameter.Value = t.REMAINING_TICKETS;
                remaining_ticketsParameter.ParameterName = "@REMAINING_TICKETS";
                AddnewFlight.Parameters.Add(remaining_ticketsParameter);

                SqlParameter inventoryParameter = new SqlParameter();
                inventoryParameter.SqlDbType = SqlDbType.Int;
                inventoryParameter.Value = t.Inventory;
                inventoryParameter.ParameterName = "@INVENTORY";
                AddnewFlight.Parameters.Add(inventoryParameter);

                connection.Open();
                AddnewFlight.ExecuteNonQuery();
                connection.Close();
            }
        }


        
        public Flight Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Flight> GetAll()
        {
            throw new NotImplementedException();
        }

        public Dictionary<Flight, int> GetAllFlightsVacancy()
        {
            throw new NotImplementedException();
        }

        public Flight GetFlightById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Flight> GetFlightsByCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public IList<Flight> GetFlightsByDepatrureDate(DateTime departureDate)
        {
            throw new NotImplementedException();
        }

        public IList<Flight> GetFlightsByDestinationCountry(int countryCode)
        {
            throw new NotImplementedException();
        }

        public IList<Flight> GetFlightsByLandingDate(DateTime landingDate)
        {
            throw new NotImplementedException();
        }

        public IList<Flight> GetFlightsByOriginCountry(int countryCode)
        {
            throw new NotImplementedException();
        }

        public void Remove(Flight t)
        {
            throw new NotImplementedException();
        }

        public void Update(Flight t)
        {
            throw new NotImplementedException();
        }
    }    
}
