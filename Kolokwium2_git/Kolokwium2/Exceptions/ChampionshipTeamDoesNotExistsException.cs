using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Kolokwium2.Exceptions
{
    public class ChampionshipTeamDoesNotExistsException : Exception
    {
        public ChampionshipTeamDoesNotExistsException()
        {
        }

        public ChampionshipTeamDoesNotExistsException(string message) : base(message)
        {
        }

        public ChampionshipTeamDoesNotExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ChampionshipTeamDoesNotExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
