// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Resource.Order
{
    using System.Collections.Generic;
    using MercadoPago.Http;

    /// <summary>
    /// Order class.
    /// </summary>
    public class Order : IResource
    {
        /// <summary>
        /// Order ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Type of Order.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Total amount of the Order.
        /// </summary>
        public string TotalAmount { get; set; }

        /// <summary>
        /// Total paid amount of the Order.
        /// </summary>
        public string TotalPaidAmount { get; set; }

        /// <summary>
        /// External reference.
        /// </summary>
        public string ExternalReference { get; set; }

        /// <summary>
        /// Country Code.
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Status of Order.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Status Detail of Order.
        /// </summary>
        public string StatusDetail { get; set; }

        /// <summary>
        /// Capture Mode of Order.
        /// </summary>
        public string CaptureMode { get; set; }

        /// <summary>
        /// User ID.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Client token.
        /// </summary>
        public string ClientToken { get; set; }

        /// <summary>
        /// Configures which processing modes to use.
        /// </summary>
        public string ProcessingMode { get; set; }

        /// <summary>
        /// Description of Order.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Origin of the order.
        /// </summary>
        public string Marketplace { get; set; }

        /// <summary>
        /// Fee collected by a marketplace or MercadoPago Application.
        /// </summary>
        public string MarketplaceFee { get; set; }

        /// <summary>
        /// Date of expiration.
        /// </summary>
        public string ExpirationTime { get; set; }

        /// <summary>
        /// Order creation date.
        /// </summary>
        public string CreatedDate { get; set; }

        /// <summary>
        /// Order update date.
        /// </summary>
        public string LastUpdatedDate { get; set; }

        /// <summary>
        /// Checkout available at.
        /// </summary>
        public string CheckoutAvailableAt { get; set; }

        /// <summary>
        /// Transactions information.
        /// </summary>
        public OrderTransaction Transactions { get; set; }

        /// <summary>
        /// Items information.
        /// </summary>
        public IList<OrderItems> Items { get; set; }

        /// <summary>
        /// Integration data information.
        /// </summary>
        public OrderIntegrationData IntegrationData { get; set; }

        /// <summary>
        /// Payer information.
        /// </summary>
        public OrderPayer Payer { get; set; }

        /// <summary>
        /// Response from API.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }

        /// <summary>
        /// Additional info for the order.
        /// </summary>
        public IDictionary<string, object> AdditionalInfo { get; set; }
    }
}
