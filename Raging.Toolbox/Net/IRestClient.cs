using System;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Raging.Toolbox.Net.Adapters;

namespace Raging.Toolbox.Net
{
    public interface IRestClient
    {
        Task<RestClientResponseMessage<TResponse>> Get<TRequest, TResponse>();

        Task<RestClientResponseMessage<TResponse>> Get<TRequest, TResponse>(TRequest request);

        Task<RestClientResponseMessage<TResponse>> Get<TRequest, TResponse, TContentFormatter>(
            TRequest request,
            TContentFormatter contentFormatter)
            where TContentFormatter : MediaTypeFormatter;

        Task<RestClientResponseMessage<TResponse>> Get<TRequest, TResponse, TContentFormatter>(
            TRequest request,
            TContentFormatter contentFormatter,
            Func<IHttpResponseMessageAdapter, bool> responseValidator)
            where TContentFormatter : MediaTypeFormatter;

        Task<RestClientResponseMessage<TResponse>> Get<TRequest, TResponse, TContentFormatter>(
            TRequest request,
            TContentFormatter contentFormatter,
            Func<IHttpResponseMessageAdapter, bool> responseValidator,
            Func<IHttpContentAdapter, TContentFormatter, Task<TResponse>> contentReader)
            where TContentFormatter : MediaTypeFormatter;

        Task<RestClientResponseMessage> Post<TRequest>(TRequest request);

        Task<RestClientResponseMessage> Post<TRequest, TRequestFormatter>(
            TRequest request,
            TRequestFormatter requestFormatter)
            where TRequestFormatter : MediaTypeFormatter;

        Task<RestClientResponseMessage> Post<TRequest, TRequestFormatter>(
            TRequest request,
            TRequestFormatter requestFormatter,
            Func<IHttpResponseMessageAdapter, bool> responseValidator)
            where TRequestFormatter : MediaTypeFormatter;

        Task<RestClientResponseMessage<TResponse>> Post<TRequest, TResponse>(TRequest request);

        Task<RestClientResponseMessage<TResponse>> Post<TRequest, TResponse, TRequestFormatter, TContentFormatter>(
            TRequest request,
            TRequestFormatter requestFormatter,
            TContentFormatter contentFormatter)
            where TRequestFormatter : MediaTypeFormatter
            where TContentFormatter : MediaTypeFormatter;

        Task<RestClientResponseMessage<TResponse>> Post<TRequest, TResponse, TRequestFormatter, TContentFormatter>(
            TRequest request,
            TRequestFormatter requestFormatter,
            TContentFormatter contentFormatter,
            Func<IHttpResponseMessageAdapter, bool> responseValidator)
            where TRequestFormatter : MediaTypeFormatter
            where TContentFormatter : MediaTypeFormatter;

        Task<RestClientResponseMessage<TResponse>> Post<TRequest, TResponse, TRequestFormatter, TContentFormatter>(
            TRequest request,
            TRequestFormatter requestFormatter,
            TContentFormatter contentFormatter,
            Func<IHttpResponseMessageAdapter, bool> responseValidator,
            Func<IHttpContentAdapter, TContentFormatter, Task<TResponse>> contentReader)
            where TRequestFormatter : MediaTypeFormatter
            where TContentFormatter : MediaTypeFormatter;

        Task<RestClientResponseMessage> Put<TRequest>(TRequest request);

        Task<RestClientResponseMessage> Put<TRequest, TRequestFormatter>(
            TRequest request,
            TRequestFormatter requestFormatter)
            where TRequestFormatter : MediaTypeFormatter;

        Task<RestClientResponseMessage> Put<TRequest, TRequestFormatter>(
            TRequest request,
            TRequestFormatter requestFormatter,
            Func<IHttpResponseMessageAdapter, bool> responseValidator)
            where TRequestFormatter : MediaTypeFormatter;

        Task<RestClientResponseMessage<TResponse>> Put<TRequest, TResponse>(TRequest request);

        Task<RestClientResponseMessage<TResponse>> Put<TRequest, TResponse, TRequestFormatter, TContentFormatter>(
            TRequest request,
            TRequestFormatter requestFormatter,
            TContentFormatter contentFormatter)
            where TRequestFormatter : MediaTypeFormatter
            where TContentFormatter : MediaTypeFormatter;

        Task<RestClientResponseMessage<TResponse>> Put<TRequest, TResponse, TRequestFormatter, TContentFormatter>(
            TRequest request,
            TRequestFormatter requestFormatter,
            TContentFormatter contentFormatter,
            Func<IHttpResponseMessageAdapter, bool> responseValidator)
            where TRequestFormatter : MediaTypeFormatter
            where TContentFormatter : MediaTypeFormatter;

        Task<RestClientResponseMessage<TResponse>> Put<TRequest, TResponse, TRequestFormatter, TContentFormatter>(
            TRequest request,
            TRequestFormatter requestFormatter,
            TContentFormatter contentFormatter,
            Func<IHttpResponseMessageAdapter, bool> responseValidator,
            Func<IHttpContentAdapter, TContentFormatter, Task<TResponse>> contentReader)
            where TRequestFormatter : MediaTypeFormatter
            where TContentFormatter : MediaTypeFormatter;

        Task<RestClientResponseMessage<TResponse>> Delete<TRequest, TResponse>(TRequest request);

        Task<RestClientResponseMessage<TResponse>> Delete<TRequest, TResponse, TContentFormatter>(
            TRequest request,
            TContentFormatter contentFormatter)
            where TContentFormatter : MediaTypeFormatter;

        Task<RestClientResponseMessage<TResponse>> Delete<TRequest, TResponse, TContentFormatter>(
            TRequest request,
            TContentFormatter contentFormatter,
            Func<IHttpResponseMessageAdapter, bool> responseValidator)
            where TContentFormatter : MediaTypeFormatter;

        Task<RestClientResponseMessage<TResponse>> Delete<TRequest, TResponse, TContentFormatter>(
            TRequest request,
            TContentFormatter contentFormatter,
            Func<IHttpResponseMessageAdapter, bool> responseValidator,
            Func<IHttpContentAdapter, TContentFormatter, Task<TResponse>> contentReader)
            where TContentFormatter : MediaTypeFormatter;
    }
}