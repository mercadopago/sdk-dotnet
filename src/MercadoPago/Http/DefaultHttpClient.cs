namespace MercadoPago.Http
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Default <see cref="IHttpClient"/> implementation that uses
    /// <see cref="HttpClient"/> to make HTTP requests.
    /// </summary>
    public class DefaultHttpClient : IHttpClient
    {
        private static string JSON_CONTENT_TYPE = "application/json";

        private static readonly Lazy<HttpClient> LazyDefaultHttpClient = new Lazy<HttpClient>(() =>
        {
            return new HttpClient
            {
                Timeout = DefaultHttpTimeout,
            };
        });

        static DefaultHttpClient()
        {
            // Enable support for TLS 1.2
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultHttpClient"/> class.
        /// </summary>
        /// <param name="httpClient">
        /// The <see cref="HttpClient"/> instance to use.
        /// If <c>null</c> a default instance of <see cref="HttpClient"/> will be created.
        /// </param>
        public DefaultHttpClient(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultHttpClient"/> class.
        /// </summary>
        public DefaultHttpClient()
            : this(LazyDefaultHttpClient.Value)
        {
        }

        /// <summary>
        /// Default HTTP timeout.
        /// </summary>
        public static TimeSpan DefaultHttpTimeout => TimeSpan.FromSeconds(30);

        /// <summary>
        /// <see cref="HttpClient"/> used in requests.
        /// </summary>
        public HttpClient HttpClient { get; }

        /// <summary>
        /// Sends a HTTP request to MercadoPago's APIs.
        /// </summary>
        /// <param name="request">Request data.</param>
        /// <param name="retryStrategy">Strategy to be used when it is necessary to retry the request.</param>
        /// <param name="cancellationToken">Cancellation token to cancel operation.</param>
        /// <returns>A Task with response data.</returns>
        public async Task<MercadoPagoResponse> SendAsync(
            MercadoPagoRequest request,
            IRetryStrategy retryStrategy,
            CancellationToken cancellationToken)
        {
            HttpResponseMessage httpResponse = null;
            int numberRetries = 0;
            Exception exception;
            HttpRequestMessage httpRequest;

            while (true)
            {
                httpRequest = CreateHttpRequest(request);

                try
                {
                    httpResponse = await HttpClient.SendAsync(httpRequest,
                        HttpCompletionOption.ResponseHeadersRead,
                        cancellationToken).ConfigureAwait(false);
                    exception = null;
                }
                catch (Exception ex)
                {
                    exception = ex;
                }

                RetryResponse retryResponse = retryStrategy.ShouldRetry(
                    httpRequest,
                    httpResponse,
                    IsRetryableError(exception, cancellationToken),
                    numberRetries);

                if (!retryResponse.Retry)
                {
                    break;
                }

                // Dispose HTTP response if if will retry
                if (httpResponse != null)
                {
                    httpResponse.Dispose();
                }

                numberRetries++;
                await Task.Delay(retryResponse.Delay).ConfigureAwait(false);
            }

            // Dispose HTTP request
            if (httpRequest != null)
            {
                httpRequest.Dispose();
            }

            if (exception != null)
            {
                throw exception;
            }

            return await MapResponse(httpResponse);
        }

        private static HttpRequestMessage CreateHttpRequest(MercadoPagoRequest request)
        {
            var httpRequest = new HttpRequestMessage
            {
                Method = MapHttpMethod(request.Method),
                RequestUri = new Uri(request.Url),
            };

            if (request.Content != null)
            {
                httpRequest.Content = new StringContent(request.Content, Encoding.UTF8, JSON_CONTENT_TYPE);
            }

            if (request.Headers != null)
            {
                foreach (var header in request.Headers)
                {
                    httpRequest.Headers.Add(header.Key, header.Value);
                }
            }

            return httpRequest;
        }

        private static async Task<MercadoPagoResponse> MapResponse(HttpResponseMessage httpResponse)
        {
            string content = null;
            Stream stream = await httpResponse.Content.ReadAsStreamAsync()
                .ConfigureAwait(false);
            if (stream != null)
            {
                using (var sr = new StreamReader(stream))
                {
                    content = await sr.ReadToEndAsync().ConfigureAwait(false);
                }
            }

            var headers = new Dictionary<string, string>();
            foreach (var httpHeader in httpResponse.Headers)
            {
                headers.Add(httpHeader.Key, string.Join(",", httpHeader.Value));
            }

            // Disposes HTTP response
            httpResponse.Dispose();

            return new MercadoPagoResponse(
                (int)httpResponse.StatusCode,
                headers,
                content);
        }

        private static bool IsRetryableError(Exception exception,
            CancellationToken cancellationToken) =>
            exception != null
            && (exception is HttpRequestException
                || exception is OperationCanceledException
                    && !cancellationToken.IsCancellationRequested);

        private static System.Net.Http.HttpMethod MapHttpMethod(HttpMethod httpMethod)
        {
            switch (httpMethod)
            {
                case HttpMethod.GET:
                    return System.Net.Http.HttpMethod.Get;
                case HttpMethod.POST:
                    return System.Net.Http.HttpMethod.Post;
                case HttpMethod.PUT:
                    return System.Net.Http.HttpMethod.Put;
                case HttpMethod.DELETE:
                    return System.Net.Http.HttpMethod.Delete;
                default:
                    throw new ArgumentException($"Invalid value of {nameof(httpMethod)}.");
            }
        }
    }
}
