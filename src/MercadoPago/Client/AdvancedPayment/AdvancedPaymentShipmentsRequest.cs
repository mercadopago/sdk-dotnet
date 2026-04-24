namespace MercadoPago.Client.AdvancedPayment
{
    /// <summary>
    /// Shipping details for the items associated with an advanced payment.
    /// Included as part of <see cref="AdvancedPaymentAdditionalInfoRequest"/> to improve fraud analysis.
    /// </summary>
    public class AdvancedPaymentShipmentsRequest
    {
        /// <summary>
        /// Destination address where the purchased items will be delivered.
        /// </summary>
        /// <see cref="AdvancedPaymentReceiverAddressRequest"/>
        public AdvancedPaymentReceiverAddressRequest ReceiverAddress { get; set; }
    }
}
