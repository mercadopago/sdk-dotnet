namespace MercadoPago.Client.AdvancedPayment
{
    using System.Collections.Generic;

    /// <summary>
    /// Supplementary data attached to an advanced payment request to improve fraud analysis and
    /// conversion rates. Send as much information as possible for best results.
    /// </summary>
    /// <see cref="AdvancedPaymentCreateRequest"/>
    public class AdvancedPaymentAdditionalInfoRequest
    {
        /// <summary>
        /// IP address from which the payment request originates. Required only for bank transfer payments.
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// List of items being purchased in this advanced payment.
        /// </summary>
        public IList<AdvancedPaymentItemRequest> Items { get; set; }

        /// <summary>
        /// Additional payer details used for fraud scoring and risk analysis.
        /// </summary>
        /// <see cref="AdvancedPaymentAdditionalInfoPayerRequest"/>
        public AdvancedPaymentAdditionalInfoPayerRequest Payer { get; set; }

        /// <summary>
        /// Shipping details for the items associated with this advanced payment.
        /// </summary>
        /// <see cref="AdvancedPaymentShipmentsRequest"/>
        public AdvancedPaymentShipmentsRequest Shipments { get; set; }
    }
}
