namespace MercadoPago.Client.Preference
{
    /// <summary>
    /// Category-specific metadata for an item. Provides additional details for travel-related
    /// items, such as passenger identity and route information, used for fraud prevention analysis.
    /// </summary>
    /// <seealso cref="PreferenceItemRequest"/>
    public class PreferenceCategoryDescriptorRequest
    {
        /// <summary>
        /// Passenger information for travel-related items (e.g., airline tickets).
        /// </summary>
        /// <seealso cref="PreferencePassengerRequest"/>
        public PreferencePassengerRequest Passenger { get; set; }

        /// <summary>
        /// Route information for travel-related items, including departure and destination details.
        /// </summary>
        /// <seealso cref="PreferenceRouteRequest"/>
        public PreferenceRouteRequest Route { get; set; }
    }
}
