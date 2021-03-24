namespace MercadoPago.Resource.Payment
{
    using MercadoPago.Resource.Common;

    /// <summary>
    /// Receiver address.
    /// </summary>
    public class PaymentReceiverAddress : Address
    {
        /// <summary>
        /// State.
        /// </summary>
        public string StateName { get; set; }

        /// <summary>
        /// City.
        /// </summary>
        public string CityName { get; set; }

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
