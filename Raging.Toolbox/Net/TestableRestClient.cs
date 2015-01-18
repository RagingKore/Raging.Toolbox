using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Raging.Toolbox.Extensions;
using Raging.Toolbox.Net.Adapters;

namespace Raging.Toolbox.Net
{
    // TODO: To be continued... SS.
    public class BetterJsonMediaTypeFormatter : JsonMediaTypeFormatter
    {
        public BetterJsonMediaTypeFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
            this.Indent = true;
            this.UseDataContractJsonSerializer = false;
        }
    }

    public sealed class TestableRestClient : IRestClient
    {
        private const string ErrorMessage = "Invalid response received: {0} ({1}). {2}";

        private static readonly Func<IHttpResponseMessageAdapter, bool> DefaultResponseValidator = response => response.IsSuccessStatusCode;
        private static readonly JsonMediaTypeFormatter DefaultFormatter = new JsonMediaTypeFormatter { Indent = true, UseDataContractJsonSerializer = false };

        private readonly IHttpClientAdapter client;

        public TestableRestClient(IHttpClientAdapter client)
        {
            this.client = client;
        }

        public TestableRestClient(IHttpClientAdapter client, string baseAddress, bool ensureSuccessStatusCode)
        {
            this.client                  = client;
            this.BaseAddress             = new Uri(baseAddress);
            this.EnsureSuccessStatusCode = ensureSuccessStatusCode;
        }

        public Uri BaseAddress 
        {
            get { return this.client.BaseAddress; }
            set { this.client.BaseAddress = value; }
        }

        public bool EnsureSuccessStatusCode { get; set; }

        #region . Get .

        public Task<RestClientResponseMessage<TResponse>> Get<TRequest, TResponse>()
        {
            return this.Get<TRequest, TResponse>(Activator.CreateInstance<TRequest>());
        }

        public Task<RestClientResponseMessage<TResponse>> Get<TRequest, TResponse>(TRequest request)
        {
            return this.Get<TRequest, TResponse, JsonMediaTypeFormatter>(
                request, 
                DefaultFormatter, 
                DefaultResponseValidator);
        }

        public Task<RestClientResponseMessage<TResponse>> Get<TRequest, TResponse, TContentFormatter>(
            TRequest request,
            TContentFormatter contentFormatter)
            where TContentFormatter : MediaTypeFormatter
        {
            return this.Get(
                request,
                contentFormatter,
                DefaultResponseValidator,
                DefaultContentReader<TResponse, TContentFormatter>);
        }

        public Task<RestClientResponseMessage<TResponse>> Get<TRequest, TResponse, TContentFormatter>(
            TRequest request,
            TContentFormatter contentFormatter,
            Func<IHttpResponseMessageAdapter, bool> responseValidator)
            where TContentFormatter : MediaTypeFormatter
        {
            return this.Get(
                request,
                contentFormatter,
                responseValidator,
                DefaultContentReader<TResponse, TContentFormatter>);
        }

        public Task<RestClientResponseMessage<TResponse>> Get<TRequest, TResponse, TContentFormatter>(
            TRequest request,
            TContentFormatter contentFormatter,
            Func<IHttpResponseMessageAdapter, bool> responseValidator,
            Func<IHttpContentAdapter, TContentFormatter, Task<TResponse>> contentReader)
            where TContentFormatter : MediaTypeFormatter
        {
            return this.SendRequest(
                request,
                contentFormatter,
                contentFormatter,
                responseValidator,
                contentReader,
                (httpClient, route, clientRequest, clientRequestFormatter) 
                    => this.client.GetAsync(route, HttpCompletionOption.ResponseContentRead));
        }

        #endregion

        #region . Post .

        public Task<RestClientResponseMessage<TResponse>> Post<TRequest, TResponse>(TRequest request)
        {
            return this.Post<TRequest, TResponse, JsonMediaTypeFormatter, JsonMediaTypeFormatter>(
                request,
                DefaultFormatter,
                DefaultFormatter,
                DefaultResponseValidator);
        }

        public Task<RestClientResponseMessage<TResponse>> Post<TRequest, TResponse, TRequestFormatter, TContentFormatter>(
            TRequest request,
            TRequestFormatter requestFormatter,
            TContentFormatter contentFormatter)
            where TRequestFormatter : MediaTypeFormatter
            where TContentFormatter : MediaTypeFormatter
        {
            return this.Post(
                request,
                requestFormatter,
                contentFormatter,
                DefaultResponseValidator,
                DefaultContentReader<TResponse, TContentFormatter>);
        }

        public Task<RestClientResponseMessage<TResponse>> Post<TRequest, TResponse, TRequestFormatter, TContentFormatter>(
            TRequest request,
            TRequestFormatter requestFormatter,
            TContentFormatter contentFormatter,
            Func<IHttpResponseMessageAdapter, bool> responseValidator)
            where TRequestFormatter : MediaTypeFormatter
            where TContentFormatter : MediaTypeFormatter
        {
            return this.Post(
                request,
                requestFormatter,
                contentFormatter,
                responseValidator,
                DefaultContentReader<TResponse, TContentFormatter>);
        }

        public Task<RestClientResponseMessage<TResponse>> Post<TRequest, TResponse, TRequestFormatter, TContentFormatter>(
            TRequest request,
            TRequestFormatter requestFormatter,
            TContentFormatter contentFormatter,
            Func<IHttpResponseMessageAdapter, bool> responseValidator,
            Func<IHttpContentAdapter, TContentFormatter, Task<TResponse>> contentReader)
            where TRequestFormatter : MediaTypeFormatter
            where TContentFormatter : MediaTypeFormatter
        {
            return this.SendRequest(
                request,
                requestFormatter,
                contentFormatter,
                responseValidator,
                contentReader,
                (httpClient, route, clientRequest, clientRequestFormatter) => this.client.PostAsync(route, request, clientRequestFormatter));
        }

        #endregion

        #region . Put .

        public Task<RestClientResponseMessage<TResponse>> Put<TRequest, TResponse>(TRequest request)
        {
            return this.Put<TRequest, TResponse, JsonMediaTypeFormatter, JsonMediaTypeFormatter>(
                request,
                DefaultFormatter,
                DefaultFormatter,
                DefaultResponseValidator);
        }

        public Task<RestClientResponseMessage<TResponse>> Put<TRequest, TResponse, TRequestFormatter, TContentFormatter>(
            TRequest request,
            TRequestFormatter requestFormatter,
            TContentFormatter contentFormatter)
            where TRequestFormatter : MediaTypeFormatter
            where TContentFormatter : MediaTypeFormatter
        {
            return this.Put(
                request,
                requestFormatter,
                contentFormatter,
                DefaultResponseValidator,
                DefaultContentReader<TResponse, TContentFormatter>);
        }

        public Task<RestClientResponseMessage<TResponse>> Put<TRequest, TResponse, TRequestFormatter, TContentFormatter>(
            TRequest request,
            TRequestFormatter requestFormatter,
            TContentFormatter contentFormatter,
            Func<IHttpResponseMessageAdapter, bool> responseValidator)
            where TRequestFormatter : MediaTypeFormatter
            where TContentFormatter : MediaTypeFormatter
        {
            return this.Put(
                request,
                requestFormatter,
                contentFormatter,
                responseValidator,
                DefaultContentReader<TResponse, TContentFormatter>);
        }

        public Task<RestClientResponseMessage<TResponse>> Put<TRequest, TResponse, TRequestFormatter, TContentFormatter>(
            TRequest request,
            TRequestFormatter requestFormatter,
            TContentFormatter contentFormatter,
            Func<IHttpResponseMessageAdapter, bool> responseValidator,
            Func<IHttpContentAdapter, TContentFormatter, Task<TResponse>> contentReader)
            where TRequestFormatter : MediaTypeFormatter
            where TContentFormatter : MediaTypeFormatter
        {
            return this.SendRequest(
                request,
                requestFormatter,
                contentFormatter,
                responseValidator,
                contentReader,
                (httpClient, route, clientRequest, clientRequestFormatter) => this.client.PutAsync(route, request, clientRequestFormatter));
        }

        #endregion

        #region . Delete .

        public Task<RestClientResponseMessage<TResponse>> Delete<TRequest, TResponse>(TRequest request)
        {
            return this.Delete<TRequest, TResponse, JsonMediaTypeFormatter>(
                request,
                DefaultFormatter,
                DefaultResponseValidator);
        }

        public Task<RestClientResponseMessage<TResponse>> Delete<TRequest, TResponse, TContentFormatter>(
            TRequest request,
            TContentFormatter contentFormatter)
            where TContentFormatter : MediaTypeFormatter
        {
            return this.Delete<TRequest, TResponse, TContentFormatter>(
                request,
                contentFormatter,
                DefaultResponseValidator);
        }

        public Task<RestClientResponseMessage<TResponse>> Delete<TRequest, TResponse, TContentFormatter>(
            TRequest request,
            TContentFormatter contentFormatter,
            Func<IHttpResponseMessageAdapter, bool> responseValidator)
            where TContentFormatter : MediaTypeFormatter
        {
            return this.Delete(
                request,
                contentFormatter,
                responseValidator,
                DefaultContentReader<TResponse, TContentFormatter>);
        }

        public Task<RestClientResponseMessage<TResponse>> Delete<TRequest, TResponse, TContentFormatter>(
            TRequest request,
            TContentFormatter contentFormatter,
            Func<IHttpResponseMessageAdapter, bool> responseValidator,
            Func<IHttpContentAdapter, TContentFormatter, Task<TResponse>> contentReader)
            where TContentFormatter : MediaTypeFormatter
        {
            return this.SendRequest(
                request,
                contentFormatter,
                contentFormatter,
                responseValidator,
                contentReader,
                (httpClient, route, clientRequest, clientRequestFormatter) => this.client.DeleteAsync(route));
        }

        #endregion

        public async Task<RestClientResponseMessage<TResponse>> SendRequest<TRequest, TResponse, TRequestFormatter, TContentFormatter>(
            TRequest request,
            TRequestFormatter requestFormatter,
            TContentFormatter contentFormatter,
            Func<IHttpResponseMessageAdapter, bool> responseValidator,
            Func<IHttpContentAdapter, TContentFormatter, Task<TResponse>> contentReader,
            Func<IHttpClientAdapter, string, TRequest, TRequestFormatter, Task<IHttpResponseMessageAdapter>> requestSender)
            where TRequestFormatter : MediaTypeFormatter
            where TContentFormatter : MediaTypeFormatter
        {
            Guard.Null(() => request, request);
            Guard.Null(() => requestFormatter, requestFormatter);
            Guard.Null(() => contentFormatter, contentFormatter);
            Guard.Null(() => responseValidator, responseValidator);
            Guard.Null(() => contentReader, contentReader);
            Guard.Null(() => requestSender, requestSender);

            // get route from request object
            var route = typeof(TRequest)
                .GetAttributeValue<RouteAttribute, string>(attribute => attribute.Address);

            if(route.IsNullOrWhiteSpace())
                throw new Exception("Route not defined.");
            
            // generate route
            if(route.Contains("{"))
            {
                foreach(var property in typeof(TRequest)
                    .GetProperties()
                    .Where(info => info.CanRead))
                {
                    var key = "{" + property.Name + "}";

                    if(route.Contains(key))
                    {
                        var value = property
                            .GetValue(request, new object[] { });

                        string textValue;

                        if (typeof(ICollection<object>).IsAssignableFrom(property.PropertyType) && key.IsAfter("?", route))
                        {
                            textValue = ((ICollection<object>)value).Join();
                        }
                        else
                        {
                            textValue = value.ToString();
                        }

                        route = route.Replace(key, textValue);    
                    }
                }
            }

            // send request
            var responseMessage = await requestSender(this.client, route, request, requestFormatter);

            // validate response
            var responseIsValid = responseValidator(responseMessage);

            // read body content and deserialize it
            if(responseIsValid)
                return new RestClientResponseMessage<TResponse>(
                    responseMessage.StatusCode, 
                    await contentReader(responseMessage.Content, contentFormatter));

            // throw exception if configured
            if(this.EnsureSuccessStatusCode)
            {
                throw new HttpRequestException(
                    ErrorMessage.FormatWith(
                        (int)responseMessage.StatusCode, 
                        responseMessage.StatusCode,
                        Environment.NewLine + await responseMessage.Content.ReadAsStringAsync()));
            }

            // return a request result with the raw info
            return new RestClientResponseMessage<TResponse>(
                responseMessage.StatusCode, 
                await responseMessage.Content.ReadAsStringAsync());
        }

        private static Task<TResponse> DefaultContentReader<TResponse, TFormatter>(IHttpContentAdapter responseContent, TFormatter formatter)
          where TFormatter : MediaTypeFormatter
        {
            return responseContent.ReadAsAsync<TResponse>(new[] { formatter });
        }
    }
}