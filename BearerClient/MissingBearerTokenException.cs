using System.Runtime.Serialization;

namespace BearerClient
{
    public class MissingBearerTokenException : ApplicationException
    {
        public MissingBearerTokenException()
        {
        }

        public MissingBearerTokenException(string message) : base(message)
        {
        }

        public MissingBearerTokenException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MissingBearerTokenException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
