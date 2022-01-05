namespace MercadoPago.Client
{
    using System.Collections.Generic;
    using MercadoPago.Config;
    using MercadoPago.Http;

    /// <summary>
    /// Class that overrides/adds some options per request.
    /// </summary>
    public class RequestOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestOptions"/> class.
        /// </summary>
        public RequestOptions()
        {
            CustomHeaders = new Dictionary<string, string>();
        }

        /// <summary>
        /// Overrides your global access token configured in <see cref="MercadoPagoConfig"/>.
        /// Your access token is a credential configured to your account.
        /// You can see and/or configure your credentials
        /// <a href="https://www.mercadopago.com/developers/panel/credentials">here</a>
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// <see cref="IRetryStrategy"/> that will be used to the HTTP request.
        /// </summary>
        public IRetryStrategy RetryStrategy { get; set; }

        /// <summary>
        /// Custom headers to send in the HTTP request.
        /// </summary>
        /// <remarks>
        /// The headers <c>Content-Type</c>, <c>Authorization</c>, <c>User-Agent</c>,
        /// <c>X-Product-Id</c>, <c>X-Corporation-Id</c>, <c>X-Integrator-Id</c>
        /// and <c>X-Platform-Id</c> will be disconsidered.
        /// </remarks>
        public IDictionary<string, string> CustomHeaders { get; }
    }
}
