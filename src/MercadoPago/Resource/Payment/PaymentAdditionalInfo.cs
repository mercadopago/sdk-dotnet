namespace MercadoPago.Resource.Payment
{
    using System.Collections.Generic;

    /// <summary>
    /// Data that could improve fraud analysis and conversion rates.
    /// Try to send as much information as possible.
    /// </summary>
    public class PaymentAdditionalInfo
    {
        /// <summary>
        /// IP from where the request comes from (only for bank transfers).
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// List of items to be paid.
        /// </summary>
        public IList<PaymentItem> Items { get; set; }

        /// <summary>
        /// Payer's information.
        /// </summary>
        public PaymentAdditionalInfoPayer Payer { get; set; }

        /// <summary>
        /// Shipping information.
        /// </summary>
        public PaymentShipments Shipments { get; set; }
    }
}
