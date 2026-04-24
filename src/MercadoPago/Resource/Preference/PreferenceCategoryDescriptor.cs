namespace MercadoPago.Resource.Preference
{
    /// <summary>
    /// Represents category-specific metadata for a <see cref="PreferenceItem"/>.
    /// Used primarily for travel-related items to provide passenger and flight route details,
    /// which help with fraud prevention and industry-specific compliance.
    /// </summary>
    public class PreferenceCategoryDescriptor
    {
        /// <summary>
        /// Passenger details associated with this item (e.g., for airline tickets).
        /// </summary>
        public PreferencePassenger Passenger { get; set; }

        /// <summary>
        /// Flight route details including departure, destination, and dates (e.g., for airline tickets).
        /// </summary>
        public PreferenceRoute Route { get; set; }
    }
}
