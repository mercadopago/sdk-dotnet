namespace MercadoPago.Resource.Preference
{
    /// <summary>
    /// Item information related to the category.
    /// </summary>
    public class PreferenceCategoryDescriptor
    {
        /// <summary>
        /// Passenger information.
        /// </summary>
        public PreferencePassenger Passenger { get; set; }

        /// <summary>
        /// Flight information.
        /// </summary>
        public PreferenceRoute Route { get; set; }
    }
}
