namespace MercadoPago.Client
{
    using System.Collections.Generic;
    using MercadoPago.Config;
    using MercadoPago.Http;

    /// <summary>
    /// Per-request configuration that can override global defaults set in <see cref="MercadoPagoConfig"/>.
    /// Pass an instance of this class to any client method to customize the access token,
    /// retry strategy, or HTTP headers for that single API call.
    /// </summary>
    public class RequestOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestOptions"/> class
        /// with an empty <see cref="CustomHeaders"/> dictionary.
        /// </summary>
        public RequestOptions()
        {
            CustomHeaders = new Dictionary<string, string>();
        }

        /// <summary>
        /// Access token that overrides the global <see cref="MercadoPagoConfig.AccessToken"/>
        /// for this request only. Leave <c>null</c> or empty to use the global token.
        /// You can view and manage your credentials
        /// <a href="https://www.mercadopago.com/developers/panel/credentials">here</a>.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Retry strategy that overrides the global <see cref="MercadoPagoConfig.RetryStrategy"/>
        /// for this request. When <c>null</c>, the global strategy is used.
        /// </summary>
        public IRetryStrategy RetryStrategy { get; set; }

        /// <summary>
        /// Additional HTTP headers to include in this request.
        /// </summary>
        /// <remarks>
        /// Headers that are managed internally by the SDK are ignored even if added here.
        /// The following headers will be discarded: <c>Content-Type</c>, <c>Authorization</c>,
        /// <c>User-Agent</c>, <c>X-Product-Id</c>, <c>X-Corporation-Id</c>,
        /// <c>X-Integrator-Id</c>, and <c>X-Platform-Id</c>.
        /// </remarks>
        public IDictionary<string, string> CustomHeaders { get; }
    }
}
