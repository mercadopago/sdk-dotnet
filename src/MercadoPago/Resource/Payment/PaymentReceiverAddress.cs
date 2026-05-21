namespace MercadoPago.Resource.Payment
{
    using MercadoPago.Resource.Common;

    /// <summary>
    /// Shipping destination address for the payment's purchased items.
    /// Extends the base <see cref="Address"/> with state, city, floor,
    /// and apartment information. Used within <see cref="PaymentShipments"/>.
    /// </summary>
    public class PaymentReceiverAddress : Address
    {
        /// <summary>
        /// Name of the state or province for the shipping destination.
        /// </summary>
        public string StateName { get; set; }

        /// <summary>
        /// Name of the city for the shipping destination.
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// Floor number or identifier within the building at the
        /// shipping destination.
        /// </summary>
        public string Floor { get; set; }

        /// <summary>
        /// Apartment number or identifier within the building at the
        /// shipping destination.
        /// </summary>
        public string Apartment { get; set; }
    }
}
