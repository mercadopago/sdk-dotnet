// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Resource.Order
{
    using System.Collections.Generic;
    using MercadoPago.Http;

    /// <summary>
    /// Represents a payment order from the MercadoPago Orders API, containing all details
    /// about the transaction lifecycle including items, payments, payer data, and shipping.
    /// </summary>
    public class Order : IResource
    {
        /// <summary>
        /// Unique identifier assigned by MercadoPago when the order is created.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Order type that determines the checkout and payment flow (e.g., "online").
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Total amount of the order, representing the sum of all item prices before payments.
        /// </summary>
        public string TotalAmount { get; set; }

        /// <summary>
        /// Cumulative amount that has been successfully paid toward this order.
        /// </summary>
        public string TotalPaidAmount { get; set; }

        /// <summary>
        /// External reference identifier used to correlate this order with a record in your own system.
        /// </summary>
        public string ExternalReference { get; set; }

        /// <summary>
        /// ISO 3166-1 alpha-2 country code where the order is being processed (e.g., "AR", "BR", "MX").
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// ISO 4217 currency code for the order amounts (e.g., "ARS", "BRL", "MXN").
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Current status of the order (e.g., "created", "processed", "expired", "cancelled").
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Detailed explanation of the current <see cref="Status"/>, providing additional context about the order state.
        /// </summary>
        public string StatusDetail { get; set; }

        /// <summary>
        /// Determines when the payment is captured. Use "automatic" for immediate capture or "manual" for deferred capture.
        /// </summary>
        public string CaptureMode { get; set; }

        /// <summary>
        /// MercadoPago user identifier of the seller who owns this order.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Client-side token used to authenticate the payer session during the checkout process.
        /// </summary>
        public string ClientToken { get; set; }

        /// <summary>
        /// Processing mode that determines how the payment is handled (e.g., "aggregator", "gateway").
        /// </summary>
        public string ProcessingMode { get; set; }

        /// <summary>
        /// Free-text description of the order, typically displayed to the payer during checkout.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Marketplace origin identifier indicating the platform where this order was created.
        /// </summary>
        public string Marketplace { get; set; }

        /// <summary>
        /// Fee collected by the marketplace or MercadoPago application on this order, expressed in the order currency.
        /// </summary>
        public string MarketplaceFee { get; set; }

        /// <summary>
        /// ISO 8601 timestamp after which the order can no longer be paid and transitions to "expired" status.
        /// </summary>
        public string ExpirationTime { get; set; }

        /// <summary>
        /// ISO 8601 timestamp indicating when the order was created.
        /// </summary>
        public string CreatedDate { get; set; }

        /// <summary>
        /// ISO 8601 timestamp indicating when the order was last modified.
        /// </summary>
        public string LastUpdatedDate { get; set; }

        /// <summary>
        /// ISO 8601 timestamp indicating when the checkout link becomes available for the payer.
        /// </summary>
        public string CheckoutAvailableAt { get; set; }

        /// <summary>
        /// Transaction details for this order, including associated <see cref="OrderPayment"/>,
        /// <see cref="OrderRefundItem"/>, and <see cref="OrderChargeback"/> records.
        /// </summary>
        public OrderTransaction Transactions { get; set; }

        /// <summary>
        /// List of <see cref="OrderItems"/> representing the products or services included in this order.
        /// </summary>
        public IList<OrderItems> Items { get; set; }

        /// <summary>
        /// Integration metadata containing identifiers for the corporation, application, integrator, platform, and
        /// <see cref="OrderSponsor"/> associated with this order.
        /// </summary>
        public OrderIntegrationData IntegrationData { get; set; }

        /// <summary>
        /// Information about the <see cref="OrderPayer"/> responsible for paying this order.
        /// </summary>
        public OrderPayer Payer { get; set; }

        /// <summary>
        /// Shipping details for this order, including the delivery <see cref="OrderShipmentAddress"/>.
        /// </summary>
        public OrderShipment Shipment { get; set; }

        /// <summary>
        /// Raw HTTP response returned by the MercadoPago API for this request.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }

        /// <summary>
        /// Dictionary of supplementary key-value data attached to the order for custom integration needs.
        /// </summary>
        public IDictionary<string, object> AdditionalInfo { get; set; }

        /// <summary>
        /// List of <see cref="OrderTax"/> entries representing taxes applied to this order.
        /// </summary>
        public IList<OrderTax> Taxes { get; set; }

        /// <summary>
        /// Discount configuration applied to this order, including payment-method-specific discounts.
        /// See <see cref="OrderDiscounts"/> for details.
        /// </summary>
        public OrderDiscounts Discounts { get; set; }

        /// <summary>
        /// Type-specific response data for this order, such as QR code information for in-store payments.
        /// See <see cref="OrderTypeResponse"/>.
        /// </summary>
        public OrderTypeResponse TypeResponse { get; set; }
    }
}
