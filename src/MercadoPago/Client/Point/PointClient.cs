namespace MercadoPago.Client.Point
{
    using System.Threading;
    using System.Threading.Tasks;
    using MercadoPago.Error;
    using MercadoPago.Http;
    using MercadoPago.Resource;
    using MercadoPago.Resource.Point;
    using MercadoPago.Serialization;

    /// <summary>
    /// Client for the MercadoPago Point Integration API
    /// (<c>/point/integration-api</c>). Provides operations to create, retrieve,
    /// and cancel payment intents on physical Point card-reader devices, and to list
    /// available devices linked to the authenticated account.
    /// </summary>
    /// <remarks>
    /// For more information check the documentation
    /// <a href="https://www.mercadopago.com/developers/en/reference/in-person-payments/point/orders/create-order/post">here</a>.
    /// </remarks>
    public class PointClient : MercadoPagoClient<PointPaymentIntent>
    {
        private readonly PointDevicesClient devicesClient;
        private readonly PointDeviceOperatingModeClient operatingModeClient;
        private readonly PointPaymentIntentListClient intentListClient;
        private readonly PointPaymentIntentStatusClient intentStatusClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="PointClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public PointClient(IHttpClient httpClient, ISerializer serializer)
            : base(httpClient, serializer)
        {
            devicesClient = new PointDevicesClient(httpClient, serializer);
            operatingModeClient = new PointDeviceOperatingModeClient(httpClient, serializer);
            intentListClient = new PointPaymentIntentListClient(httpClient, serializer);
            intentStatusClient = new PointPaymentIntentStatusClient(httpClient, serializer);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PointClient"/> class.
        /// </summary>
        /// <param name="httpClient">The http client that will be used in HTTP requests.</param>
        public PointClient(IHttpClient httpClient)
            : this(httpClient, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PointClient"/> class.
        /// </summary>
        /// <param name="serializer">
        /// The serializer that will be used to serialize the HTTP requests content
        /// and to deserialize the HTTP response content.
        /// </param>
        public PointClient(ISerializer serializer)
            : this(null, serializer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PointClient"/> class.
        /// </summary>
        public PointClient()
            : this(null, null)
        {
        }

        /// <summary>
        /// Creates a payment intent on a specific Point device asynchronously.
        /// </summary>
        /// <param name="deviceId">The unique identifier of the target Point device.</param>
        /// <param name="request">A <see cref="PointCreatePaymentIntentRequest"/> with the transaction details.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the created <see cref="PointPaymentIntent"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public Task<PointPaymentIntent> CreateAsync(
            string deviceId,
            PointCreatePaymentIntentRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync(
                $"/point/integration-api/devices/{EncodePathParam(deviceId)}/payment-intents",
                HttpMethod.POST,
                request,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Creates a payment intent on a specific Point device synchronously.
        /// </summary>
        /// <param name="deviceId">The unique identifier of the target Point device.</param>
        /// <param name="request">A <see cref="PointCreatePaymentIntentRequest"/> with the transaction details.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>The created <see cref="PointPaymentIntent"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public PointPaymentIntent Create(
            string deviceId,
            PointCreatePaymentIntentRequest request,
            RequestOptions requestOptions = null)
        {
            return Send(
                $"/point/integration-api/devices/{EncodePathParam(deviceId)}/payment-intents",
                HttpMethod.POST,
                request,
                requestOptions);
        }

        /// <summary>
        /// Retrieves a payment intent by its ID asynchronously.
        /// </summary>
        /// <param name="paymentIntentId">The unique identifier of the payment intent.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the <see cref="PointPaymentIntent"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public Task<PointPaymentIntent> GetAsync(
            string paymentIntentId,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync(
                $"/point/integration-api/payment-intents/{EncodePathParam(paymentIntentId)}",
                HttpMethod.GET,
                null,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Retrieves a payment intent by its ID synchronously.
        /// </summary>
        /// <param name="paymentIntentId">The unique identifier of the payment intent.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>The <see cref="PointPaymentIntent"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public PointPaymentIntent Get(
            string paymentIntentId,
            RequestOptions requestOptions = null)
        {
            return Send(
                $"/point/integration-api/payment-intents/{EncodePathParam(paymentIntentId)}",
                HttpMethod.GET,
                null,
                requestOptions);
        }

        /// <summary>
        /// Cancels a pending payment intent on a specific device asynchronously.
        /// </summary>
        /// <param name="deviceId">The unique identifier of the Point device holding the intent.</param>
        /// <param name="paymentIntentId">The unique identifier of the payment intent to cancel.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
        /// <returns>A task whose result is the cancelled <see cref="PointPaymentIntent"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public Task<PointPaymentIntent> CancelAsync(
            string deviceId,
            string paymentIntentId,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return SendAsync(
                $"/point/integration-api/devices/{EncodePathParam(deviceId)}/payment-intents/{EncodePathParam(paymentIntentId)}",
                HttpMethod.DELETE,
                null,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Cancels a pending payment intent on a specific device synchronously.
        /// </summary>
        /// <param name="deviceId">The unique identifier of the Point device holding the intent.</param>
        /// <param name="paymentIntentId">The unique identifier of the payment intent to cancel.</param>
        /// <param name="requestOptions">Per-request overrides for access token, retry strategy, and custom headers. May be <c>null</c>.</param>
        /// <returns>The cancelled <see cref="PointPaymentIntent"/> resource.</returns>
        /// <exception cref="MercadoPagoException">If an unexpected exception occurs during the request.</exception>
        /// <exception cref="MercadoPagoApiException">If the API returns an error response.</exception>
        public PointPaymentIntent Cancel(
            string deviceId,
            string paymentIntentId,
            RequestOptions requestOptions = null)
        {
            return Send(
                $"/point/integration-api/devices/{EncodePathParam(deviceId)}/payment-intents/{EncodePathParam(paymentIntentId)}",
                HttpMethod.DELETE,
                null,
                requestOptions);
        }

        /// <summary>
        /// Retrieves all Point devices associated with the authenticated account asynchronously.
        /// </summary>
        public Task<PointDevicesResponse> GetDevicesAsync(
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return devicesClient.SendAsync(
                "/point/integration-api/devices",
                HttpMethod.GET,
                null,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Retrieves all Point devices associated with the authenticated account.
        /// </summary>
        public PointDevicesResponse GetDevices(RequestOptions requestOptions = null)
        {
            return devicesClient.Send(
                "/point/integration-api/devices",
                HttpMethod.GET,
                null,
                requestOptions);
        }

        /// <summary>
        /// Changes the operating mode of a specific Point device asynchronously.
        /// </summary>
        public Task<PointDeviceOperatingModeResponse> ChangeDeviceOperatingModeAsync(
            string deviceId,
            PointDeviceOperatingModeRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return operatingModeClient.SendAsync(
                $"/point/integration-api/devices/{EncodePathParam(deviceId)}",
                HttpMethod.PATCH,
                request,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Changes the operating mode of a specific Point device.
        /// </summary>
        public PointDeviceOperatingModeResponse ChangeDeviceOperatingMode(
            string deviceId,
            PointDeviceOperatingModeRequest request,
            RequestOptions requestOptions = null)
        {
            return operatingModeClient.Send(
                $"/point/integration-api/devices/{EncodePathParam(deviceId)}",
                HttpMethod.PATCH,
                request,
                requestOptions);
        }

        /// <summary>
        /// Retrieves a list of payment intent events within a date range asynchronously.
        /// </summary>
        public Task<PointPaymentIntentListResponse> GetPaymentIntentListAsync(
            PointPaymentIntentListRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return intentListClient.SendAsync(
                "/point/integration-api/payment-intents/events",
                HttpMethod.GET,
                request,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Retrieves a list of payment intent events within a date range.
        /// </summary>
        public PointPaymentIntentListResponse GetPaymentIntentList(
            PointPaymentIntentListRequest request,
            RequestOptions requestOptions = null)
        {
            return intentListClient.Send(
                "/point/integration-api/payment-intents/events",
                HttpMethod.GET,
                request,
                requestOptions);
        }

        /// <summary>
        /// Retrieves the status events of a specific payment intent asynchronously.
        /// </summary>
        public Task<PointPaymentIntentStatusResponse> GetPaymentIntentStatusAsync(
            string paymentIntentId,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return intentStatusClient.SendAsync(
                $"/point/integration-api/payment-intents/{EncodePathParam(paymentIntentId)}/events",
                HttpMethod.GET,
                null,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Retrieves the status events of a specific payment intent.
        /// </summary>
        public PointPaymentIntentStatusResponse GetPaymentIntentStatus(
            string paymentIntentId,
            RequestOptions requestOptions = null)
        {
            return intentStatusClient.Send(
                $"/point/integration-api/payment-intents/{EncodePathParam(paymentIntentId)}/events",
                HttpMethod.GET,
                null,
                requestOptions);
        }
    }

    internal class PointDevicesClient : MercadoPagoClient<PointDevicesResponse>
    {
        public PointDevicesClient(IHttpClient httpClient, ISerializer serializer)
            : base(httpClient, serializer) { }

        public new Task<PointDevicesResponse> SendAsync(string path, HttpMethod method, object request, RequestOptions opts, CancellationToken ct)
            => base.SendAsync(path, method, request, opts, ct);

        public new PointDevicesResponse Send(string path, HttpMethod method, object request, RequestOptions opts)
            => base.Send(path, method, request, opts);
    }

    internal class PointDeviceOperatingModeClient : MercadoPagoClient<PointDeviceOperatingModeResponse>
    {
        public PointDeviceOperatingModeClient(IHttpClient httpClient, ISerializer serializer)
            : base(httpClient, serializer) { }

        public new Task<PointDeviceOperatingModeResponse> SendAsync(string path, HttpMethod method, object request, RequestOptions opts, CancellationToken ct)
            => base.SendAsync(path, method, request, opts, ct);

        public new PointDeviceOperatingModeResponse Send(string path, HttpMethod method, object request, RequestOptions opts)
            => base.Send(path, method, request, opts);
    }

    internal class PointPaymentIntentListClient : MercadoPagoClient<PointPaymentIntentListResponse>
    {
        public PointPaymentIntentListClient(IHttpClient httpClient, ISerializer serializer)
            : base(httpClient, serializer) { }

        public new Task<PointPaymentIntentListResponse> SendAsync(string path, HttpMethod method, object request, RequestOptions opts, CancellationToken ct)
            => base.SendAsync(path, method, request, opts, ct);

        public new PointPaymentIntentListResponse Send(string path, HttpMethod method, object request, RequestOptions opts)
            => base.Send(path, method, request, opts);
    }

    internal class PointPaymentIntentStatusClient : MercadoPagoClient<PointPaymentIntentStatusResponse>
    {
        public PointPaymentIntentStatusClient(IHttpClient httpClient, ISerializer serializer)
            : base(httpClient, serializer) { }

        public new Task<PointPaymentIntentStatusResponse> SendAsync(string path, HttpMethod method, object request, RequestOptions opts, CancellationToken ct)
            => base.SendAsync(path, method, request, opts, ct);

        public new PointPaymentIntentStatusResponse Send(string path, HttpMethod method, object request, RequestOptions opts)
            => base.Send(path, method, request, opts);
    }
}
