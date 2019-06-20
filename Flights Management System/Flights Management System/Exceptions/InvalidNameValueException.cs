using System;
using System.Runtime.Serialization;

namespace Flights_Management_System
{
    [Serializable]
    internal class InvalidNameValueException : Exception
    {
        public InvalidNameValueException()
        {
        }

        public InvalidNameValueException(string message) : base(message)
        {
        }

        public InvalidNameValueException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidNameValueException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}