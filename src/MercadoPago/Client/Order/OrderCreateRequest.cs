// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Client.Order
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Request payload for creating a new payment order via <c>POST /v1/orders</c>.
    /// Contains all the information needed to define an order: type, amounts, transactions,
    /// payer details, line items, configuration, and shipping.
    /// </summary>
    /// <remarks>
    /// Check the parameters
    /// <a href="https://www.mercadopago.com/developers/en/reference/order/online-payments/create/post/">here</a>.
    /// </remarks>
    /// <seealso cref="OrderClient.Create(OrderCreateRequest, RequestOptions)"/>
    /// <seealso cref="OrderClient.CreateAsync(OrderCreateRequest, RequestOptions, System.Threading.CancellationToken)"/>
    public class OrderCreateRequest : IdempotentRequest
    {
        /// <summary>
        /// Order type identifier. Determines the processing flow (e.g., "online" for e-commerce transactions).
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Unique external reference that you can use to synchronize this order with your own payment system.
        /// </summary>
        public string ExternalReference { get; set; }

        /// <summary>
        /// Total monetary amount of the order, expressed as a decimal string (e.g., "100.50").
        /// </summary>
        public string TotalAmount { get; set; }

        /// <summary>
        /// ISO 4217 currency code for the order (e.g., "BRL", "ARS", "MXN").
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Determines when the payment funds are captured. Defaults to "automatic_async".
        /// Use "manual" to authorize first and capture later via <see cref="OrderClient.Capture(string, RequestOptions)"/>.
        /// </summary>
        [JsonProperty("capture_mode")]
        public string CaptureMode { get; set; } = "automatic_async";

        /// <summary>
        /// Configures which processing mode to use for the order (e.g., "aggregator" or "gateway").
        /// </summary>
        public string ProcessingMode { get; set; }

        /// <summary>
        /// Human-readable description of the order, shown to the payer during checkout.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Marketplace identifier indicating the origin of the payment when operating as a marketplace.
        /// </summary>
        public string Marketplace { get; set; }

        /// <summary>
        /// Fee amount collected by a marketplace or MercadoPago application, expressed as a decimal string.
        /// </summary>
        public string MarketplaceFee { get; set; }

        /// <summary>
        /// Expiration time for the order in ISO 8601 format. After this time the order can no longer be processed.
        /// </summary>
        public string ExpirationTime { get; set; }

        /// <summary>
        /// Date and time (ISO 8601) from which the checkout becomes available to the payer.
        /// </summary>
        public string CheckoutAvailableAt { get; set; }

        /// <summary>
        /// Transaction information containing the list of payments associated with the order.
        /// </summary>
        /// <seealso cref="OrderTransactionRequest"/>
        public OrderTransactionRequest Transactions { get; set; }

        /// <summary>
        /// Payer details including name, email, identification, phone, and address.
        /// </summary>
        /// <seealso cref="OrderPayerRequest"/>
        public OrderPayerRequest Payer { get; set; }

        /// <summary>
        /// List of line items (products or services) included in the order.
        /// </summary>
        /// <seealso cref="OrderItemsRequest"/>
        public IList<OrderItemsRequest> Items { get; set; }

        /// <summary>
        /// Order-level configuration for payment method restrictions and online checkout behavior.
        /// </summary>
        /// <seealso cref="OrderConfigRequest"/>
        public OrderConfigRequest Config { get; set; }

        /// <summary>
        /// Shipping information for the order, including the delivery address.
        /// </summary>
        /// <seealso cref="OrderShipmentRequest"/>
        public OrderShipmentRequest Shipment { get; set; }

        /// <summary>
        /// Free-form dictionary for any additional metadata to attach to the order.
        /// </summary>
        public IDictionary<string, object> AdditionalInfo { get; set; }
    }
}
