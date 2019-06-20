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
    class TicketDAOMSSQL : ITicketDAO
    {
        private bool DoesFlightExistByFlihtID(long fLIGHT_ID)
        {
            int result;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDBConnection"].ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "DOES_FLIGHT_EXIST_BY_ID";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter fLIGHT_IDParameter = new SqlParameter();
                fLIGHT_IDParameter.SqlDbType = SqlDbType.Int;
                fLIGHT_IDParameter.SqlValue = fLIGHT_ID;
                fLIGHT_IDParameter.ParameterName = "@FLIGHTID";

                SqlParameter returnParameter = new SqlParameter();
                returnParameter.SqlDbType = SqlDbType.Int;
                returnParameter.Direction = ParameterDirection.Output;
                returnParameter.ParameterName = "@RETURN";

                sqlCommand.Parameters.Add(fLIGHT_IDParameter);
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

        private int CheckInventory(long fLIGHT_ID)
        {
            if (!DoesFlightExistByFlihtID(fLIGHT_ID))
            {
                throw new InsufficientDataException();
            }

            int inventory;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDBConnection"].ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "CHECK_INVENTORY";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter fLIGHT_IDParameter = new SqlParameter();
                fLIGHT_IDParameter.SqlDbType = SqlDbType.Int;
                fLIGHT_IDParameter.SqlValue = fLIGHT_ID;
                fLIGHT_IDParameter.ParameterName = "@FLIGHT_ID";

                SqlParameter returnParameter = new SqlParameter();
                returnParameter.SqlDbType = SqlDbType.Int;
                returnParameter.Direction = ParameterDirection.Output;
                returnParameter.ParameterName = "@RETURN";

                sqlCommand.Parameters.Add(fLIGHT_IDParameter);
                sqlCommand.Parameters.Add(returnParameter);

                connection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                inventory = (int)returnParameter.Value;
                connection.Close();
            }

            return inventory;
        }
        public void Add(Ticket t)
        {
            long iD = 0;
            long fLIGHT_ID = 0;
            long cUSTOMER_ID = 0;
            int Amount = 0;

            if (iD == 0 || cUSTOMER_ID == 0 || fLIGHT_ID <= 0)
            {
                throw new InsufficientDataException();
            }

            if (!DoesFlightExistByFlihtID(fLIGHT_ID))
            {
                throw new FlightDoesNotExistException();
            }

            if (CheckInventory(fLIGHT_ID) < Amount)
            {
                throw new InsufficientInventoryException();
            }
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDBConnection"].ConnectionString))
            {
                SqlCommand newOrder = new SqlCommand();
                newOrder.Connection = connection;
                newOrder.CommandText = "BUY_NEW_ORDER";
                newOrder.CommandType = CommandType.StoredProcedure;

                SqlParameter cUSTOMER_IDParameter = new SqlParameter();
                cUSTOMER_IDParameter.SqlDbType = SqlDbType.Int;
                cUSTOMER_IDParameter.Value = cUSTOMER_ID;
                cUSTOMER_IDParameter.ParameterName = "@CUSTOMER_ID";
                newOrder.Parameters.Add(cUSTOMER_IDParameter);

                SqlParameter fLIGHT_IDParameter = new SqlParameter();
                fLIGHT_IDParameter.SqlDbType = SqlDbType.Int;
                fLIGHT_IDParameter.Value = fLIGHT_ID;
                fLIGHT_IDParameter.ParameterName = "@FLIGHT_ID";
                newOrder.Parameters.Add(fLIGHT_IDParameter);

                SqlParameter amountParameter = new SqlParameter();
                amountParameter.SqlDbType = SqlDbType.Int;
                amountParameter.Value = Amount;
                amountParameter.ParameterName = "@AMOUNT";
                newOrder.Parameters.Add(amountParameter);

                SqlParameter priceParameter = new SqlParameter();
                priceParameter.SqlDbType = SqlDbType.Int;
                priceParameter.ParameterName = "@PRICE";
                priceParameter.Value = 0;
                newOrder.Parameters.Add(priceParameter);

                connection.Open();
                newOrder.ExecuteNonQuery();
                connection.Close();
            }
        }

        

        public Ticket Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Ticket> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(Ticket t)
        {
            throw new NotImplementedException();
        }

        public void Update(Ticket t)
        {
            throw new NotImplementedException();
        }
    }
}
