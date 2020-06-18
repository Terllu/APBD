using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.Exceptions
{
    public class PlayerDoesNotExistsException : Exception
    {
        public PlayerDoesNotExistsException()
        {
        }

        public PlayerDoesNotExistsException(string message) : base(message)
        {
        }

        public PlayerDoesNotExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
