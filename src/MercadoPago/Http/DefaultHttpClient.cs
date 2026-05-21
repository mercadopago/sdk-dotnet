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
    /// Default <see cref="IHttpClient"/> implementation that sends HTTP requests using
    /// <see cref="HttpClient"/> and supports automatic retries via <see cref="IRetryStrategy"/>.
    /// </summary>
    /// <remarks>
    /// <para>
    /// A lazily-initialized, shared <see cref="HttpClient"/> with a 30-second timeout is used
    /// when no explicit instance is provided. TLS 1.2 support is enabled in the static
    /// constructor via <see cref="ServicePointManager.SecurityProtocol"/>.
    /// </para>
    /// <para>
    /// The <see cref="SendAsync"/> method implements a retry loop: after each failed attempt it
    /// consults the supplied <see cref="IRetryStrategy"/> to decide whether to retry and how
    /// long to wait. Transient errors (<see cref="HttpRequestException"/> and non-user-initiated
    /// <see cref="OperationCanceledException"/>) are treated as retryable.
    /// </para>
    /// </remarks>
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
        /// Initializes a new instance of the <see cref="DefaultHttpClient"/> class with the
        /// specified <see cref="HttpClient"/>.
        /// </summary>
        /// <param name="httpClient">
        /// The <see cref="HttpClient"/> to use for outgoing requests. Callers own the
        /// lifetime of this instance and should not dispose it while the SDK is in use.
        /// </param>
        public DefaultHttpClient(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultHttpClient"/> class using the
        /// shared, lazily-created <see cref="HttpClient"/> singleton with a 30-second timeout.
        /// </summary>
        public DefaultHttpClient()
            : this(LazyDefaultHttpClient.Value)
        {
        }

        /// <summary>
        /// Gets the default timeout applied to the shared <see cref="HttpClient"/> instance. Value is 30 seconds.
        /// </summary>
        public static TimeSpan DefaultHttpTimeout => TimeSpan.FromSeconds(30);

        /// <summary>
        /// Gets the underlying <see cref="HttpClient"/> instance that executes outgoing HTTP requests.
        /// </summary>
        public HttpClient HttpClient { get; }

        /// <summary>
        /// Sends an HTTP request to MercadoPago APIs, automatically retrying on transient failures
        /// according to the provided <paramref name="retryStrategy"/>.
        /// </summary>
        /// <param name="request">
        /// The <see cref="MercadoPagoRequest"/> containing the URL, HTTP method, headers, and optional body.
        /// </param>
        /// <param name="retryStrategy">
        /// The <see cref="IRetryStrategy"/> consulted after each attempt to determine whether a
        /// retry should be performed and how long to delay before the next attempt.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> that can be used to cancel the operation. If the token
        /// is already cancelled, the exception is rethrown immediately without retrying.
        /// </param>
        /// <returns>
        /// A <see cref="Task{MercadoPagoResponse}"/> representing the asynchronous operation,
        /// containing the mapped API response on success.
        /// </returns>
        /// <exception cref="HttpRequestException">Thrown when a network-level error persists after all retries.</exception>
        /// <exception cref="OperationCanceledException">Thrown when the caller cancels the request via <paramref name="cancellationToken"/>.</exception>
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
