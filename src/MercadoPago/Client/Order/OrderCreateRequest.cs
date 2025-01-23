namespace MercadoPago.Client.Order
{
    using System.Collections.Generic;

    /// <summary>
    /// Parameters to create a order.
    /// </summary>
    /// <remarks>
    /// Check the parameters
    /// <a href="https://www.mercadopago.com/developers/en/reference/order/online-payments/create/post/">here</a>.
    /// </remarks>
    public class OrderCreateRequest : IdempotentRequest 
    {
        /// <summary>
        /// Order type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Total amount of the order.
        /// </summary>
        public string TotalAmount { get; set; }

        /// <summary>
        /// Reference you can synchronize with your payment system.
        /// </summary>
        public string ExternalReference { get; set; }

        /// <summary>
        /// Capture mode.
        /// </summary>
        public string CaptureMode { get; set; }

        /// <summary>
        /// Configures which procesing modes to use.
        /// </summary>
        public string ProcessingMode { get; set; }

        /// <summary>
        /// Description of the order.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Origin of the payment.
        /// </summary>
        public string Marketplace { get; set; }

        /// <summary>
        /// Fee collected by a marketplace or MercadoPago Application.
        /// </summary>
        public string MarketplaceFee { get; set; }

        /// <summary>
        /// Expiration time of the order.
        /// </summary>
        public string ExpirationTime { get; set; }

        /// <summary>
        /// Order transaction information.
        /// </summary>
        public OrderTransactionRequest Transactions { get; set; }

        /// <summary>
        /// Payer's information.
        /// </summary>
        public OrderPayerRequest Payer { get; set; }

        /// <summary>
        /// Items information.
        /// </summary>
        public IList<OrderItemsRequest> Items { get; set; }
    }
}