using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Kolokwium2.Exceptions
{
    public class PlayerAgeToHighException : Exception
    {
        public PlayerAgeToHighException()
        {
        }

        public PlayerAgeToHighException(string message) : base(message)
        {
        }

        public PlayerAgeToHighException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PlayerAgeToHighException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
