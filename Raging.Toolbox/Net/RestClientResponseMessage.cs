using System.Net;

namespace Raging.Toolbox.Net
{
    public class RestClientResponseMessage
    {
        public RestClientResponseMessage(HttpStatusCode statusCode)
        {
            this.StatusCode = statusCode;
            this.RawResponse = null;
            this.Successfull = true;
        }

        public RestClientResponseMessage(HttpStatusCode statusCode, string rawResponse)
        {
            this.StatusCode = statusCode;
            this.RawResponse = rawResponse;
            this.Successfull = false;
        }

        public HttpStatusCode StatusCode { get; private set; }

        public bool Successfull { get; private set; }

        public string RawResponse { get; private set; }
    }

    public class RestClientResponseMessage<TResponse> : RestClientResponseMessage
    {
        public RestClientResponseMessage(HttpStatusCode statusCode, TResponse response)
            : base(statusCode)
        {
            this.Response = response;
        }

        public RestClientResponseMessage(HttpStatusCode statusCode, string rawResponse)
            : base(statusCode, rawResponse)
        {
        }

        public TResponse Response { get; private set; }
    }
}