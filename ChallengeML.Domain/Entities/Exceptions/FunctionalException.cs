using System.Net;

namespace ChallengeML.Domain.Entities.Exceptions
{
    public class FunctionalException : Exception
    {
        public string ErrorCode { get; }
        public HttpStatusCode StatusCode { get; }

        public FunctionalException(string message, HttpStatusCode statusCode) : base(message)
        {
            ErrorCode = statusCode.ToString();
            StatusCode = statusCode;
        }

        public FunctionalException(string message, HttpStatusCode statusCode, Exception innerException) : base(message, innerException)
        {
            ErrorCode = statusCode.ToString();
            StatusCode = statusCode;
        }
    }
}
