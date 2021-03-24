namespace MercadoPago.Resource.AdvancedPayment
{
    using MercadoPago.Resource.Common;

    /// <summary>
    /// Receiver address.
    /// </summary>
    public class AdvancedPaymentReceiverAddress : Address
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
