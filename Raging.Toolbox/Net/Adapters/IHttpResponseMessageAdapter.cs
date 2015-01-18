using System.Net;

namespace Raging.Toolbox.Net.Adapters
{
    public interface IHttpResponseMessageAdapter
    {
        bool IsSuccessStatusCode { get; }

        HttpStatusCode StatusCode { get; }

        IHttpContentAdapter Content { get; }
    }
}