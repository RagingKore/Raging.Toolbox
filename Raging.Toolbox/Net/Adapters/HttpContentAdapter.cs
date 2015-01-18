using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace Raging.Toolbox.Net.Adapters
{
    public class HttpContentAdapter : IHttpContentAdapter
    {
        private readonly HttpContent httpContent;

        public HttpContentAdapter(HttpContent httpContent)
        {
            this.httpContent = httpContent;
        }

        public Task<T> ReadAsAsync<T>(IEnumerable<MediaTypeFormatter> formatters)
        {
            return this.httpContent.ReadAsAsync<T>(formatters);
        }

        public Task<string> ReadAsStringAsync()
        {
            return this.httpContent.ReadAsStringAsync();
        }
    }
}