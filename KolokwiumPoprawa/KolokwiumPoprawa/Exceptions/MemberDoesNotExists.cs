using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace KolokwiumPoprawa.Exceptions
{
    public class MemberDoesNotExists : Exception
    {
        public MemberDoesNotExists()
        {
        }

        public MemberDoesNotExists(string message) : base(message)
        {
        }

        public MemberDoesNotExists(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MemberDoesNotExists(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
