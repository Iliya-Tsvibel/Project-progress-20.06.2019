using System;
using System.Runtime.Serialization;

namespace Flights_Management_System.DAO
{
    [Serializable]
    internal class AirlineCompanyAlreadyExistsException : Exception
    {
        public AirlineCompanyAlreadyExistsException()
        {
        }

        public AirlineCompanyAlreadyExistsException(string message) : base(message)
        {
        }

        public AirlineCompanyAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AirlineCompanyAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}