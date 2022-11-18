using System.Net;

namespace NSE.WebApp.MVC.Extensions
{
    public class CustomHttpRequestException : Exception
    {
        public HttpStatusCode StatusCoode;

        public CustomHttpRequestException() { }

        public CustomHttpRequestException(string message, Exception innerException) 
            : base(message, innerException) { }

        public CustomHttpRequestException(HttpStatusCode statusCoode)
        {
            StatusCoode = statusCoode;
        }
    }
}
