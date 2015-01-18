using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace Raging.Toolbox.Net.Adapters
{
    public interface IHttpClientAdapter : IDisposable
    {
        Uri BaseAddress { get; set; }

        Task<IHttpResponseMessageAdapter> GetAsync(string route, HttpCompletionOption httpCompletionOption);

        Task<IHttpResponseMessageAdapter> PostAsync<TRequest>(string route, TRequest request, MediaTypeFormatter formatter);

        Task<IHttpResponseMessageAdapter> PutAsync<TRequest>(string route, TRequest request, MediaTypeFormatter formatter);

        Task<IHttpResponseMessageAdapter> DeleteAsync(string route);
    }
}