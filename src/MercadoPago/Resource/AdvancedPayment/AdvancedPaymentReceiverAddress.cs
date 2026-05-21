namespace MercadoPago.Resource.AdvancedPayment
{
    using MercadoPago.Resource.Common;

    /// <summary>
    /// Represents the shipping receiver's address within <see cref="AdvancedPaymentShipments"/>.
    /// Extends <see cref="Address"/> with floor and apartment details for more precise delivery location.
    /// </summary>
    public class AdvancedPaymentReceiverAddress : Address
    {
        /// <summary>
        /// Floor number or identifier within the building.
        /// </summary>
        public string Floor { get; set; }

        /// <summary>
        /// Apartment number or identifier within the floor.
        /// </summary>
        public string Apartment { get; set; }
    }
}
