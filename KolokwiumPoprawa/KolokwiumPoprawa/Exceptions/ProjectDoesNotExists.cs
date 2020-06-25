using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace KolokwiumPoprawa.Exceptions
{
    public class ProjectDoesNotExists : Exception
    {
        public ProjectDoesNotExists()
        {
        }

        public ProjectDoesNotExists(string message) : base(message)
        {
        }

        public ProjectDoesNotExists(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ProjectDoesNotExists(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
