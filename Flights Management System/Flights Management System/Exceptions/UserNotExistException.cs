using System;
using System.Runtime.Serialization;

namespace Flights_Management_System
{
    [Serializable]
    internal class UserNotExistException : Exception
    {
        public UserNotExistException()
        {
        }

        public UserNotExistException(string message) : base(message)
        {
        }

        public UserNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}