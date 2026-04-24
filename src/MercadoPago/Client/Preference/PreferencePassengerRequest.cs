namespace MercadoPago.Client.Preference
{
    using MercadoPago.Client.Common;

    /// <summary>
    /// Passenger identity information for travel-related items. Used within
    /// <see cref="PreferenceCategoryDescriptorRequest"/> to provide passenger details for
    /// fraud prevention analysis.
    /// </summary>
    public class PreferencePassengerRequest
    {
        /// <summary>
        /// Passenger's first name as it appears on the travel document.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Passenger's last name as it appears on the travel document.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Passenger's identification document (e.g., passport number, national ID).
        /// </summary>
        /// <seealso cref="IdentificationRequest"/>
        public IdentificationRequest Identification { get; set; }
    }
}
