namespace MercadoPago.Client.Preference
{
    using System;

    /// <summary>
    /// Route information for travel-related items, such as flight details. Used within
    /// <see cref="PreferenceCategoryDescriptorRequest"/> for fraud prevention analysis.
    /// </summary>
    public class PreferenceRouteRequest
    {
        /// <summary>
        /// Departure location (e.g., airport code like <c>"EZE"</c> or city name).
        /// </summary>
        public string Departure { get; set; }

        /// <summary>
        /// Destination location (e.g., airport code like <c>"GRU"</c> or city name).
        /// </summary>
        public string Destination { get; set; }

        /// <summary>
        /// Date and time of departure.
        /// </summary>
        public DateTimeOffset? DepartureDateTime { get; set; }

        /// <summary>
        /// Date and time of arrival at the destination.
        /// </summary>
        public DateTimeOffset? ArrivalDateTime { get; set; }

        /// <summary>
        /// Name of the carrier or airline company operating the route.
        /// </summary>
        public string Company { get; set; }
    }
}
