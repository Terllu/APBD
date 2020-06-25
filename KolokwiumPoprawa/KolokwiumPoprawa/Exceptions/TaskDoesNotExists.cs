using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace KolokwiumPoprawa.Exceptions
{
    public class TaskDoesNotExists : Exception
    {
        public TaskDoesNotExists()
        {
        }

        public TaskDoesNotExists(string message) : base(message)
        {
        }

        public TaskDoesNotExists(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TaskDoesNotExists(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
