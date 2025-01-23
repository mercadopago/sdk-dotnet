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
        /// Total amount of the order.
        /// </summary>
        public string TotalAmount { get; set; }

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
        /// Client ID.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Collector ID.
        /// </summary>        
        public string CollectorId { get; set; }

        /// <summary>
        /// Transactions information.
        /// </summary>
        public OrderTransaction Transactions { get; set; }

        /// <summary>
        /// Payer information.
        /// </summary>
        public OrderPayer Payer { get; set; }

        /// <summary>
        /// Items information.
        /// </summary>
        public IList<OrderItems> items { get; set; }

        /// <summary>
        /// Response from API.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}