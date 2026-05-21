namespace MercadoPago.Client.Payment
{
    using MercadoPago.Client.Common;

    /// <summary>
    /// Delivery address for the receiver of a shipment. Extends <see cref="AddressRequest"/>
    /// with state, city, floor, and apartment details used in <see cref="PaymentShipmentsRequest"/>.
    /// </summary>
    public class PaymentReceiverAddressRequest : AddressRequest
    {
        /// <summary>
        /// Name of the state or province for the delivery address.
        /// </summary>
        public string StateName { get; set; }

        /// <summary>
        /// Name of the city for the delivery address.
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// Floor number or identifier within the building.
        /// </summary>
        public string Floor { get; set; }

        /// <summary>
        /// Apartment number or identifier within the building.
        /// </summary>
        public string Apartment { get; set; }
    }
}
