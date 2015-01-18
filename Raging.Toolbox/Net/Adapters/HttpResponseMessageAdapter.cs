using System.Net;
using System.Net.Http;

namespace Raging.Toolbox.Net.Adapters
{
    public class HttpResponseMessageAdapter : IHttpResponseMessageAdapter
    {
        private readonly HttpResponseMessage httpResponseMessage;

        public HttpResponseMessageAdapter(HttpResponseMessage httpResponseMessage)
        {
            this.httpResponseMessage = httpResponseMessage;
        }

        public HttpStatusCode StatusCode
        {
            get
            {
                return this.httpResponseMessage.StatusCode;
            }
        }

        public bool IsSuccessStatusCode
        {
            get
            {
                return this.httpResponseMessage.IsSuccessStatusCode;
            }
        }

        public IHttpContentAdapter Content
        {
            get
            {
                return new HttpContentAdapter(this.httpResponseMessage.Content);
            }
        }
    }
}