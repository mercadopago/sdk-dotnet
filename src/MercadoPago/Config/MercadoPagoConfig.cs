namespace MercadoPago.Config
{
    using System;
    using System.Configuration;
    using System.Reflection;
    using MercadoPago.Http;
    using MercadoPago.Resource;
    using MercadoPago.Serialization;

    /// <summary>
    /// Provides centralized, global configuration for the MercadoPago .NET SDK.
    /// </summary>
    /// <remarks>
    /// This static class holds all settings that govern SDK behavior, including
    /// authentication credentials, HTTP transport, serialization, and retry policies.
    /// Properties can be set programmatically or loaded automatically from
    /// <see cref="ConfigurationManager.AppSettings"/> using well-known keys (e.g.,
    /// <c>MercadoPagoAccessToken</c>). Lazy defaults are created for
    /// <see cref="HttpClient"/>, <see cref="Serializer"/>, and <see cref="RetryStrategy"/>
    /// on first access if not explicitly configured.
    /// </remarks>
    public static class MercadoPagoConfig
    {
        private const string PRODUCT_ID = "BC32BHVTRPP001U8NHL0";
        private const int DEFAULT_MAX_HTTP_RETRIES = 2;
        private const string DEFAULT_BASE_URL = "https://api.mercadopago.com";

        private static string accessToken;
        private static string corporationId;
        private static string integratorId;
        private static string platformId;
        private static IHttpClient httpClient;
        private static ISerializer serializer;
        private static IRetryStrategy retryStrategy;

        static MercadoPagoConfig()
        {
            Version = new AssemblyName(typeof(MercadoPagoConfig).GetTypeInfo().Assembly.FullName).Version.ToString(3);
            TrackingId = $"platform:{Environment.Version.Major}|{Environment.Version},type:SDK{Version},so;";
        }

        /// <summary>
        /// Gets the current SDK version string (e.g., "2.12.1"), derived from the assembly metadata at startup.
        /// </summary>
        public static string Version { get; }

        /// <summary>
        /// Gets the tracking identifier sent in the <c>X-Tracking-Id</c> header with every API request.
        /// </summary>
        /// <remarks>
        /// Automatically composed at startup from the runtime platform version and SDK version.
        /// Used by MercadoPago to identify the SDK and runtime environment for diagnostics.
        /// </remarks>
        public static string TrackingId { get; }

        /// <summary>
        /// Gets the base URL used for all MercadoPago API requests. Defaults to <c>https://api.mercadopago.com</c>.
        /// </summary>
        public static string BaseUrl => DEFAULT_BASE_URL;

        /// <summary>
        /// Gets the internal product identifier sent in the <c>X-Product-Id</c> header for MercadoPago analytics.
        /// </summary>
        public static string ProductId => PRODUCT_ID;

        /// <summary>
        /// Your access token is a credential configured to your account.
        /// It's required to integrate with MercadoPago's APIs.
        /// You can see and/or configure your credentials
        /// <a href="https://www.mercadopago.com/developers/panel/credentials">here</a>.
        /// </summary>
        /// <remarks>
        /// You can configure the access token using the <c>MercadoPagoAccessToken</c> key in
        /// <see cref="ConfigurationManager.AppSettings"/>.
        /// </remarks>
        public static string AccessToken
        {
            get
            {
                if (string.IsNullOrWhiteSpace(accessToken) &&
                    !string.IsNullOrEmpty(ConfigurationManager.AppSettings["MercadoPagoAccessToken"]))
                {
                    accessToken = ConfigurationManager.AppSettings["MercadoPagoAccessToken"];
                }

                return accessToken;
            }
            set => accessToken = value;
        }

        /// <summary>
        /// Gets or sets the corporation identifier sent in the <c>X-Corporation-Id</c> header.
        /// </summary>
        /// <remarks>
        /// Falls back to the <c>MercadoPagoCorporationId</c> key in
        /// <see cref="ConfigurationManager.AppSettings"/> when not set programmatically.
        /// Used by marketplace or multi-account integrations to identify the corporation.
        /// </remarks>
        public static string CorporationId
        {
            get
            {
                if (string.IsNullOrWhiteSpace(corporationId) &&
                    !string.IsNullOrEmpty(ConfigurationManager.AppSettings["MercadoPagoCorporationId"]))
                {
                    corporationId = ConfigurationManager.AppSettings["MercadoPagoCorporationId"];
                }

                return corporationId;
            }
            set => corporationId = value;
        }

        /// <summary>
        /// Gets or sets the integrator identifier sent in the <c>X-Integrator-Id</c> header.
        /// </summary>
        /// <remarks>
        /// Falls back to the <c>MercadoPagoIntegratorId</c> key in
        /// <see cref="ConfigurationManager.AppSettings"/> when not set programmatically.
        /// Identifies the third-party integrator for commission tracking and analytics.
        /// </remarks>
        public static string IntegratorId
        {
            get
            {
                if (string.IsNullOrWhiteSpace(integratorId) &&
                    !string.IsNullOrEmpty(ConfigurationManager.AppSettings["MercadoPagoIntegratorId"]))
                {
                    integratorId = ConfigurationManager.AppSettings["MercadoPagoIntegratorId"];
                }

                return integratorId;
            }
            set => integratorId = value;
        }

        /// <summary>
        /// Gets or sets the platform identifier sent in the <c>X-Platform-Id</c> header.
        /// </summary>
        /// <remarks>
        /// Falls back to the <c>MercadoPagoPlatformId</c> key in
        /// <see cref="ConfigurationManager.AppSettings"/> when not set programmatically.
        /// Identifies the e-commerce platform (e.g., WooCommerce, Magento) that hosts the integration.
        /// </remarks>
        public static string PlatformId
        {
            get
            {
                if (string.IsNullOrWhiteSpace(platformId) &&
                    !string.IsNullOrEmpty(ConfigurationManager.AppSettings["MercadoPagoPlatformId"]))
                {
                    platformId = ConfigurationManager.AppSettings["MercadoPagoPlatformId"];
                }

                return platformId;
            }
            set => platformId = value;
        }

        /// <summary>
        /// Gets or sets the <see cref="IHttpClient"/> used to execute all HTTP requests against MercadoPago APIs.
        /// </summary>
        /// <remarks>
        /// When not explicitly set, a <see cref="DefaultHttpClient"/> wrapping a shared
        /// <see cref="System.Net.Http.HttpClient"/> instance is created on first access.
        /// To supply a custom <see cref="System.Net.Http.HttpClient"/> (e.g., with a proxy or custom handler),
        /// wrap it in a <see cref="DefaultHttpClient"/>:
        /// <code>
        /// var httpClient = new System.Net.Http.HttpClient();
        /// MercadoPagoConfig.HttpClient = new DefaultHttpClient(httpClient);
        /// </code>
        /// </remarks>
        public static IHttpClient HttpClient
        {
            get
            {
                if (httpClient == null)
                {
                    httpClient = new DefaultHttpClient();
                }
                return httpClient;
            }
            set => httpClient = value;
        }

        /// <summary>
        /// Gets or sets the <see cref="ISerializer"/> used to serialize request objects to JSON
        /// and deserialize API responses into <see cref="IResource"/> instances.
        /// </summary>
        /// <remarks>
        /// When not explicitly set, a <see cref="DefaultSerializer"/> (backed by Newtonsoft.Json
        /// with snake_case naming) is created on first access. Custom implementations must handle
        /// snake_case property mapping and the date format <c>yyyy-MM-dd'T'HH:mm:ss.fffK</c>.
        /// </remarks>
        public static ISerializer Serializer
        {
            get
            {
                if (serializer == null)
                {
                    serializer = new DefaultSerializer();
                }
                return serializer;
            }
            set => serializer = value;
        }

        /// <summary>
        /// Gets or sets the <see cref="IRetryStrategy"/> that governs automatic retry behavior for failed HTTP requests.
        /// </summary>
        /// <remarks>
        /// When not explicitly set, a <see cref="DefaultRetryStrategy"/> with a maximum of 2 retries
        /// and exponential back-off is created on first access. Replace this to customize retry
        /// limits, back-off timing, or retryable-status-code logic.
        /// </remarks>
        public static IRetryStrategy RetryStrategy
        {
            get
            {
                if (retryStrategy == null)
                {
                    retryStrategy = new DefaultRetryStrategy(DEFAULT_MAX_HTTP_RETRIES);
                }
                return retryStrategy;
            }
            set => retryStrategy = value;
        }
    }
}
