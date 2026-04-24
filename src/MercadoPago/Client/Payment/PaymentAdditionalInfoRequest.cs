namespace MercadoPago.Client.Payment
{
    using System.Collections.Generic;

    /// <summary>
    /// Additional information attached to a <see cref="PaymentCreateRequest"/> that improves
    /// fraud analysis accuracy and payment conversion rates. Sending as much data as possible
    /// is strongly recommended.
    /// </summary>
    public class PaymentAdditionalInfoRequest
    {
        /// <summary>
        /// IP address of the buyer making the request. Particularly relevant for bank transfer payments.
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// List of items being purchased in this payment.
        /// </summary>
        /// <seealso cref="PaymentItemRequest"/>
        public IList<PaymentItemRequest> Items { get; set; }

        /// <summary>
        /// Additional payer information for fraud prevention, including registration date and purchase history.
        /// </summary>
        /// <seealso cref="PaymentAdditionalInfoPayerRequest"/>
        public PaymentAdditionalInfoPayerRequest Payer { get; set; }

        /// <summary>
        /// Shipping details for the purchased items, including receiver address and delivery options.
        /// </summary>
        /// <seealso cref="PaymentShipmentsRequest"/>
        public PaymentShipmentsRequest Shipments { get; set; }
    }
}
