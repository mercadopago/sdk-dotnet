namespace MercadoPago.Resource.Payment
{
    using System.Collections.Generic;

    /// <summary>
    /// Additional information attached to a payment that can improve fraud
    /// analysis and conversion rates. Includes purchased items, payer details,
    /// and shipping data. Try to send as much information as possible.
    /// </summary>
    public class PaymentAdditionalInfo
    {
        /// <summary>
        /// IP address from which the payment request originates.
        /// Primarily used for bank transfer payments to assist with fraud detection.
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// List of items being purchased in this payment. Each item includes
        /// its title, quantity, unit price, and other product details.
        /// </summary>
        /// <seealso cref="PaymentItem"/>
        public IList<PaymentItem> Items { get; set; }

        /// <summary>
        /// Extended payer information provided for fraud prevention, including
        /// name, phone, address, and registration date on the merchant's site.
        /// </summary>
        /// <seealso cref="PaymentAdditionalInfoPayer"/>
        public PaymentAdditionalInfoPayer Payer { get; set; }

        /// <summary>
        /// Shipping information for the purchased items, including the
        /// receiver's address details.
        /// </summary>
        /// <seealso cref="PaymentShipments"/>
        public PaymentShipments Shipments { get; set; }
    }
}
