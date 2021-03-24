namespace MercadoPago.Resource.MerchantOrder
{
    using System;
    using System.Collections.Generic;
    using MercadoPago.Http;

    /// <summary>
    /// Merchant Order resource.
    /// </summary>
    /// <remarks>
    /// For more information, access
    /// <a href="https://www.mercadopago.com/developers/en/reference/merchant_orders/resource/">here</a>.
    /// </remarks>
    public class MerchantOrder : IResource
    {
        /// <summary>
        /// Order ID.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Payment preference identifier associated to the merchant order.
        /// </summary>
        public string PreferenceId { get; set; }

        /// <summary>
        /// Application ID.
        /// </summary>
        public string ApplicationId { get; set; }

        /// <summary>
        /// Show the current merchant order state.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Country identifier that merchant order belongs to.
        /// </summary>
        public string SiteId { get; set; }

        /// <summary>
        /// Payer information.
        /// </summary>
        public MerchantOrderPayer Payer { get; set; }

        /// <summary>
        /// Seller information.
        /// </summary>
        public MerchantOrderCollector Collector { get; set; }

        /// <summary>
        /// Sponsor ID.
        /// </summary>
        public long? SponsorId { get; set; }

        /// <summary>
        /// Payments information.
        /// </summary>
        public IList<MerchantOrderPayment> Payments { get; set; }

        /// <summary>
        /// Amount paid in this order.
        /// </summary>
        public decimal? PaidAmount { get; set; }

        /// <summary>
        /// Amount refunded in this Order.
        /// </summary>
        public decimal? RefundedAmount { get; set; }

        /// <summary>
        /// Shipping fee.
        /// </summary>
        public decimal? ShippingCost { get; set; }

        /// <summary>
        /// Date of creation.
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// If the Order is expired (<c>true</c>) or not (<c>false</c>).
        /// </summary>
        public bool? Cancelled { get; set; }

        /// <summary>
        /// Items information.
        /// </summary>
        public IList<MerchantOrderItem> Items { get; set; }

        /// <summary>
        /// Shipments information.
        /// </summary>
        public IList<MerchantOrderShipment> Shipments { get; set; }

        /// <summary>
        /// URL where you'd like to receive a payment notification.
        /// </summary>
        public string NotificationUrl { get; set; }

        /// <summary>
        /// Additional information.
        /// </summary>
        public string AdditionalInfo { get; set; }

        /// <summary>
        /// Reference you can synchronize with your payment system.
        /// </summary>
        public string ExternalReference { get; set; }

        /// <summary>
        /// Origin of the payment.
        /// </summary>
        public string Marketplace { get; set; }

        /// <summary>
        /// Total amount of the order.
        /// </summary>
        public decimal? TotalAmount { get; set; }

        /// <summary>
        /// Current merchant order status given the payments status.
        /// </summary>
        public string OrderStatus { get; set; }

        /// <summary>
        /// Last modified date.
        /// </summary>
        public DateTime? DateLastUpdated { get; set; }

        /// <summary>
        /// Response from API.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
