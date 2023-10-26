namespace MercadoPago.Config
{
    using System;
    using System.Configuration;
    using System.Reflection;
    using MercadoPago.Http;
    using MercadoPago.Resource;
    using MercadoPago.Serialization;

    /// <summary>
    /// Class with SDK global configurations.
    /// </summary>
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
        /// Actual SDK version.
        /// </summary>
        public static string Version { get; }

        /// <summary>
        /// SDK Tracking Id.
        /// </summary>
        public static string TrackingId { get; }

        /// <summary>
        /// Base URL of MercadoPago's APIs.
        /// </summary>
        public static string BaseUrl => DEFAULT_BASE_URL;

        /// <summary>
        /// Internal usage product id.
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
        /// Corporation identification that will be send in header <c>X-Corporation-Id</c>
        /// </summary>
        /// <remarks>
        /// You can configure the corporation ID using the <c>MercadoPagoCorporationId</c> key in
        /// <see cref="ConfigurationManager.AppSettings"/>.
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
        /// Integrator identification that will be send in header <c>X-Integrator-Id</c>
        /// </summary>
        /// <remarks>
        /// You can configure the integrator ID using the <c>MercadoPagoIntegratorId</c> key in
        /// <see cref="ConfigurationManager.AppSettings"/>.
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
        /// Platform identification that will be send in header <c>X-Platform-Id</c>
        /// </summary>
        /// <remarks>
        /// You can configure the platform ID using the <c>MercadoPagoIntegratorId</c> key in
        /// <see cref="ConfigurationManager.AppSettings"/>.
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
        /// The <see cref="IHttpClient"/> used in HTTP requests.
        /// If not informed, the <see cref="DefaultHttpClient"/> will be used
        /// with the default <see cref="System.Net.Http.HttpClient"/>.
        /// You can use your <see cref="System.Net.Http.HttpClient"/>
        /// with the <see cref="DefaultHttpClient"/>.
        /// <code>
        /// var httpClient = new System.Net.Http.HttpClient();
        /// var defaultHttpClient = new DefaultHttpClient(httpClient);
        /// </code>
        /// </summary>
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
        /// The <see cref="ISerializer"/> used to serialize request objects
        /// to JSON and deserialize API response to <see cref="IResource"/>.
        /// If not informed, the <see cref="DefaultSerializer"/> will be used.
        /// </summary>
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
        /// The <see cref="IRetryStrategy"/> used in <see cref="IHttpClient"/>.
        /// If not informed, the <see cref="DefaultRetryStrategy"/> will be used
        /// with max number retries equals <see cref="DEFAULT_MAX_HTTP_RETRIES"/>.
        /// </summary>
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
