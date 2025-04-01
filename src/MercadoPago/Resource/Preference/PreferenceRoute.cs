namespace MercadoPago.Resource.Preference
{
    using System;

    /// <summary>
    /// Flight information.
    /// </summary>
    public class PreferenceRoute
    {
        /// <summary>
        /// Derpature.
        /// </summary>
        public string Departure { get; set; }

        /// <summary>
        /// Destination.
        /// </summary>
        public string Destination { get; set; }

        /// <summary>
        /// Departure date.
        /// </summary>
        public DateTimeOffset? DepartureDateTime { get; set; }

        /// <summary>
        /// Arrival date.
        /// </summary>
        public DateTimeOffset? ArrivalDateTime { get; set; }

        /// <summary>
        /// Company.
        /// </summary>
        public string Company { get; set; }
    }
}
