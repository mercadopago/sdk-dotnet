namespace MercadoPago.Client.AdvancedPayment
{
    using MercadoPago.Client.Common;

    /// <summary>
    /// Receiver address.
    /// </summary>
    public class AdvancedPaymentReceiverAddressRequest : AddressRequest
    {
        /// <summary>
        /// Floor.
        /// </summary>
        public string Floor { get; set; }

        /// <summary>
        /// Apartment.
        /// </summary>
        public string Apartment { get; set; }
    }
}
