using System;
using System.Runtime.Serialization;

namespace Flights_Management_System
{
    [Serializable]
    internal class CustomerDoesNotExistException : Exception
    {
        public CustomerDoesNotExistException()
        {
        }

        public CustomerDoesNotExistException(string message) : base(message)
        {
        }

        public CustomerDoesNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CustomerDoesNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}