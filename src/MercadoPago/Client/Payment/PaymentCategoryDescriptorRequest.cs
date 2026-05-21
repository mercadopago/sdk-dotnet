namespace MercadoPago.Client.Payment
{
    /// <summary>
    /// Category-specific descriptor for a <see cref="PaymentItemRequest"/>.
    /// Provides additional context relevant to the item's category, such as
    /// passenger and route information for travel-related purchases.
    /// </summary>
    public class PaymentCategoryDescriptorRequest
    {
        /// <summary>
        /// Passenger details for travel-related items (e.g., airline tickets).
        /// </summary>
        /// <seealso cref="PaymentPassengerRequest"/>
        public PaymentPassengerRequest Passenger { get; set; }

        /// <summary>
        /// Flight route details including departure, destination, and travel dates.
        /// </summary>
        /// <seealso cref="PaymentRouteRequest"/>
        public PaymentRouteRequest Route { get; set; }
    }
}
