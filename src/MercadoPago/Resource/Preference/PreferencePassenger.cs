namespace MercadoPago.Resource.Preference
{
    using MercadoPago.Client.Common;

    /// <summary>
    /// Represents passenger information within a <see cref="PreferenceCategoryDescriptor"/>.
    /// Used for travel-related items (e.g., airline tickets) to provide traveler details
    /// for fraud prevention and compliance purposes.
    /// </summary>
    public class PreferencePassenger
    {
        /// <summary>
        /// Passenger's first name as it appears on their travel document.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Passenger's last name (family name) as it appears on their travel document.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Passenger's identification document (e.g., passport number, national ID).
        /// </summary>
        public IdentificationRequest Identification { get; set; }
    }
}
