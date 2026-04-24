namespace MercadoPago.Resource.MerchantOrder
{
    using System;
    using System.Collections.Generic;
    using MercadoPago.Http;

    /// <summary>
    /// Represents a Merchant Order API response. A merchant order groups one or more payments
    /// together with their associated items and shipping information, providing a unified view
    /// of a commercial transaction.
    /// </summary>
    /// <remarks>
    /// For more information, access
    /// <a href="https://www.mercadopago.com/developers/en/reference/merchant_orders/resource/">here</a>.
    /// </remarks>
    public class MerchantOrder : IResource
    {
        /// <summary>
        /// Unique identifier of the merchant order, assigned by MercadoPago.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Identifier of the <see cref="Resource.Preference.Preference"/> associated with this merchant order.
        /// Links the order to its checkout configuration.
        /// </summary>
        public string PreferenceId { get; set; }

        /// <summary>
        /// Identifier of the MercadoPago application that created this merchant order.
        /// </summary>
        public string ApplicationId { get; set; }

        /// <summary>
        /// Current status of the merchant order (e.g., <c>opened</c>, <c>closed</c>).
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// MercadoPago site identifier indicating the country where the order was created
        /// (e.g., <c>MLA</c> for Argentina, <c>MLB</c> for Brazil, <c>MLM</c> for Mexico).
        /// </summary>
        public string SiteId { get; set; }

        /// <summary>
        /// Information about the payer (buyer) associated with this merchant order.
        /// </summary>
        public MerchantOrderPayer Payer { get; set; }

        /// <summary>
        /// Information about the seller (collector) who owns this merchant order.
        /// </summary>
        public MerchantOrderCollector Collector { get; set; }

        /// <summary>
        /// Identifier of the sponsor (marketplace or platform) associated with this order.
        /// </summary>
        public long? SponsorId { get; set; }

        /// <summary>
        /// List of payments associated with this merchant order.
        /// Each <see cref="MerchantOrderPayment"/> represents an individual payment attempt or completed payment.
        /// </summary>
        public IList<MerchantOrderPayment> Payments { get; set; }

        /// <summary>
        /// Total amount that has been successfully paid for this order, in the order currency.
        /// </summary>
        public decimal? PaidAmount { get; set; }

        /// <summary>
        /// Total amount that has been refunded for this order, in the order currency.
        /// </summary>
        public decimal? RefundedAmount { get; set; }

        /// <summary>
        /// Shipping cost associated with this order, in the order currency.
        /// </summary>
        public decimal? ShippingCost { get; set; }

        /// <summary>
        /// Date and time when the merchant order was created.
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Indicates whether the order has been cancelled. <c>true</c> if the order
        /// is cancelled or expired, <c>false</c> otherwise.
        /// </summary>
        public bool? Cancelled { get; set; }

        /// <summary>
        /// List of items included in this merchant order.
        /// Each <see cref="MerchantOrderItem"/> describes a product or service being purchased.
        /// </summary>
        public IList<MerchantOrderItem> Items { get; set; }

        /// <summary>
        /// List of shipments associated with this merchant order.
        /// Each <see cref="MerchantOrderShipment"/> contains delivery tracking and address information.
        /// </summary>
        public IList<MerchantOrderShipment> Shipments { get; set; }

        /// <summary>
        /// Webhook URL where MercadoPago will send IPN (Instant Payment Notification) events
        /// about status changes on this order.
        /// </summary>
        public string NotificationUrl { get; set; }

        /// <summary>
        /// Free-text field for any additional information the merchant wants to attach to the order.
        /// </summary>
        public string AdditionalInfo { get; set; }

        /// <summary>
        /// External reference ID that the merchant can use to synchronize this order
        /// with their own payment or order management system.
        /// </summary>
        public string ExternalReference { get; set; }

        /// <summary>
        /// Origin of the payment, identifying the marketplace or platform
        /// that created this merchant order (e.g., <c>NONE</c> for direct integrations).
        /// </summary>
        public string Marketplace { get; set; }

        /// <summary>
        /// Total amount of the order, calculated as the sum of all item prices plus shipping cost.
        /// </summary>
        public decimal? TotalAmount { get; set; }

        /// <summary>
        /// Computed order status derived from the aggregate payment statuses.
        /// Possible values: <c>paid</c>, <c>partially_paid</c>, <c>unpaid</c>, <c>payment_in_process</c>.
        /// </summary>
        public string OrderStatus { get; set; }

        /// <summary>
        /// Date and time of the last update to this merchant order.
        /// </summary>
        public DateTime? DateLastUpdated { get; set; }

        /// <summary>
        /// Raw HTTP response returned by the MercadoPago API for this request.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
