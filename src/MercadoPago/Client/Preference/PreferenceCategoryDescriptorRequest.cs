namespace MercadoPago.Client.Preference
{
    /// <summary>
    /// Item information related to the category.
    /// </summary>
    public class PreferenceCategoryDescriptorRequest
    {
        /// <summary>
        /// Passenger information.
        /// </summary>
        public PreferencePassengerRequest Passenger { get; set; }

        /// <summary>
        /// Flight information.
        /// </summary>
        public PreferenceRouteRequest Route { get; set; }
    }
}
