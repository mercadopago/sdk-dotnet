namespace MercadoPago.Client.Payment
{
    using System;

    /// <summary>
    /// Flight route information for a travel-related <see cref="PaymentCategoryDescriptorRequest"/>.
    /// Describes the departure, destination, dates, and airline company for a flight segment.
    /// </summary>
    public class PaymentRouteRequest
    {
        /// <summary>
        /// Departure airport or city code (e.g., IATA code "GRU", "EZE").
        /// </summary>
        public string Departure { get; set; }

        /// <summary>
        /// Destination airport or city code (e.g., IATA code "MIA", "JFK").
        /// </summary>
        public string Destination { get; set; }

        /// <summary>
        /// Departure date and time of the flight.
        /// </summary>
        public DateTime? DepartureDateTime { get; set; }

        /// <summary>
        /// Arrival date and time of the flight.
        /// </summary>
        public DateTime? ArrivalDateTime { get; set; }

        /// <summary>
        /// Airline company name or code operating the flight.
        /// </summary>
        public string Company { get; set; }
    }
}
