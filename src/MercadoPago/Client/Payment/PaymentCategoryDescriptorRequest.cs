namespace MercadoPago.Client.Payment
{
    /// <summary>
    /// Item information related to the category.
    /// </summary>
    public class PaymentCategoryDescriptorRequest
    {
        /// <summary>
        /// Passenger information.
        /// </summary>
        public PaymentPassengerRequest Passenger { get; set; }

        /// <summary>
        /// Flight information.
        /// </summary>
        public PaymentRouteRequest Route { get; set; }

        /// <summary>
        /// Type.
        /// </summary>
        public string Type { get; set; }
    }
}
