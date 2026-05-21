namespace MercadoPago.Resource.Preference
{
    using System;

    /// <summary>
    /// Represents flight route information within a <see cref="PreferenceCategoryDescriptor"/>.
    /// Used for airline ticket purchases to provide departure, destination, and carrier details
    /// for fraud prevention and compliance.
    /// </summary>
    public class PreferenceRoute
    {
        /// <summary>
        /// Departure airport or city code (e.g., IATA code like <c>EZE</c>, <c>GRU</c>).
        /// </summary>
        public string Departure { get; set; }

        /// <summary>
        /// Destination airport or city code (e.g., IATA code like <c>MIA</c>, <c>SCL</c>).
        /// </summary>
        public string Destination { get; set; }

        /// <summary>
        /// Scheduled departure date and time of the flight, including timezone offset.
        /// </summary>
        public DateTimeOffset? DepartureDateTime { get; set; }

        /// <summary>
        /// Scheduled arrival date and time of the flight, including timezone offset.
        /// </summary>
        public DateTimeOffset? ArrivalDateTime { get; set; }

        /// <summary>
        /// Name or code of the airline or transportation company operating the route.
        /// </summary>
        public string Company { get; set; }
    }
}
