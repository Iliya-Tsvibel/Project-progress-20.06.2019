using System;
using System.Runtime.Serialization;

namespace Flights_Management_System.DAO
{
    [Serializable]
    internal class FlightDoesNotExistException : Exception
    {
        public FlightDoesNotExistException()
        {
        }

        public FlightDoesNotExistException(string message) : base(message)
        {
        }

        public FlightDoesNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FlightDoesNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}