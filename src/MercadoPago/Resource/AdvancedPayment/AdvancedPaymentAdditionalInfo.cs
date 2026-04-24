namespace MercadoPago.Resource.AdvancedPayment
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents supplementary data attached to an <see cref="AdvancedPayment"/> that can
    /// improve fraud analysis and conversion rates. Includes item details, payer information,
    /// and shipping data. Send as much information as possible.
    /// </summary>
    public class AdvancedPaymentAdditionalInfo
    {
        /// <summary>
        /// IP address from where the payment request originates. Required for bank transfer payments.
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// List of items being purchased in this advanced payment.
        /// Each <see cref="AdvancedPaymentItem"/> describes a product or service included in the transaction.
        /// </summary>
        public IList<AdvancedPaymentItem> Items { get; set; }

        /// <summary>
        /// Additional payer information used for fraud prevention, such as name, phone, and registration date.
        /// </summary>
        public AdvancedPaymentAdditionalInfoPayer Payer { get; set; }

        /// <summary>
        /// Shipping details for the purchased items, including the receiver address.
        /// </summary>
        public AdvancedPaymentShipments Shipments { get; set; }
    }
}
