namespace MercadoPago.Client.MerchantOrder
{
    using System.Collections.Generic;

    /// <summary>
    /// Parameters for create a Merchant Order.
    /// </summary>
    public class MerchantOrderCreateRequest
    {
        /// <summary>
        /// Payment preference identifier associated to the merchant order.
        /// </summary>
        public string PreferenceId { get; set; }

        /// <summary>
        /// Application ID.
        /// </summary>
        public string ApplicationId { get; set; }

        /// <summary>
        /// Country identifier that merchant order belongs to.
        /// </summary>
        public string SiteId { get; set; }

        /// <summary>
        /// Payer information.
        /// </summary>
        public MerchantOrderPayerRequest Payer { get; set; }

        /// <summary>
        /// Sponsor ID.
        /// </summary>
        public long? SponsorId { get; set; }

        /// <summary>
        /// Items information.
        /// </summary>
        public IList<MerchantOrderItemRequest> Items { get; set; }

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
    }
}
