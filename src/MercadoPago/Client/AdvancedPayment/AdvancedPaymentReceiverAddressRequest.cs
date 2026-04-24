namespace MercadoPago.Client.AdvancedPayment
{
    using MercadoPago.Client.Common;

    /// <summary>
    /// Shipping destination address for an advanced payment. Extends <see cref="AddressRequest"/>
    /// with floor and apartment details for more precise delivery targeting.
    /// </summary>
    /// <see cref="AdvancedPaymentShipmentsRequest"/>
    public class AdvancedPaymentReceiverAddressRequest : AddressRequest
    {
        /// <summary>
        /// Floor number or identifier within the building at the shipping address.
        /// </summary>
        public string Floor { get; set; }

        /// <summary>
        /// Apartment, suite, or unit number within the building at the shipping address.
        /// </summary>
        public string Apartment { get; set; }
    }
}
