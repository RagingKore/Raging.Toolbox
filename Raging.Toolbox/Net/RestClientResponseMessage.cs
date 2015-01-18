using System.Net;

namespace Raging.Toolbox.Net
{
    public class RestClientResponseMessage<TResponse>
    {
        public RestClientResponseMessage(HttpStatusCode statusCode, TResponse response)
        {
            this.StatusCode  = statusCode;
            this.Response    = response;
            this.RawResponse = null;
            this.Successfull = true;
        }

        public RestClientResponseMessage(HttpStatusCode statusCode, string rawResponse)
        {
            this.StatusCode  = statusCode;
            this.RawResponse = rawResponse;
            this.Successfull = false;
        }

        public HttpStatusCode StatusCode { get; private set; }

        public TResponse Response { get; private set; }

        public string RawResponse { get; private set; }

        public bool Successfull { get; private set; }
    }
}