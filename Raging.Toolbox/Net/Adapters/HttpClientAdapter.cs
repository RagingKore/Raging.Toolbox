using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Raging.Toolbox.Net.Adapters
{
    public class HttpClientAdapter : DisposableBase, IHttpClientAdapter
    {
        private readonly HttpClient client;

        public HttpClientAdapter()
        {
            this.client = new HttpClient();

            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Uri BaseAddress
        {
            get
            {
                return this.client.BaseAddress;
            }

            set
            {
                this.client.BaseAddress = value;
            }
        }

        public async Task<IHttpResponseMessageAdapter> GetAsync(string route, HttpCompletionOption httpCompletionOption)
        {
            return new HttpResponseMessageAdapter(await this.client.GetAsync(route, httpCompletionOption));
        }

        public async Task<IHttpResponseMessageAdapter> PostAsync<TRequest>(string route, TRequest request, MediaTypeFormatter formatter)
        {
            return new HttpResponseMessageAdapter(await this.client.PostAsync(route, request, formatter));
        }

        public async Task<IHttpResponseMessageAdapter> PutAsync<TRequest>(string route, TRequest request, MediaTypeFormatter formatter)
        {
            return new HttpResponseMessageAdapter(await this.client.PutAsync(route, request, formatter));
        }

        public async Task<IHttpResponseMessageAdapter> DeleteAsync(string route)
        {
            return new HttpResponseMessageAdapter(await this.client.DeleteAsync(route));
        }

        protected override void DisposeResources()
        {
            this.client.Dispose();
        }
    }
}
