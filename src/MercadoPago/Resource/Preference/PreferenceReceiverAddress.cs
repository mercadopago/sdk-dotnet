namespace MercadoPago.Resource.Preference
{
    using System;
    using MercadoPago.Resource.Common;

    /// <summary>
    /// Represents the shipping receiver's address within <see cref="PreferenceShipments"/>.
    /// Extends <see cref="Address"/> with country, state, city names, and precise location details.
    /// </summary>
    public class PreferenceReceiverAddress : Address
    {
        /// <summary>
        /// Full name of the country where the shipment will be delivered.
        /// </summary>
        public string CountryName { get; set; }

        /// <summary>
        /// Full name of the state or province where the shipment will be delivered.
        /// </summary>
        public string StateName { get; set; }

        /// <summary>
        /// Full name of the city where the shipment will be delivered.
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// Country name. Deprecated: use <see cref="CountryName"/> instead.
        /// </summary>
        [Obsolete("Use CountryName instead. This property will be removed in a future version.")]
        public string Country { get => CountryName; set => CountryName = value; }

        /// <summary>
        /// State name. Deprecated: use <see cref="StateName"/> instead.
        /// </summary>
        [Obsolete("Use StateName instead. This property will be removed in a future version.")]
        public string State { get => StateName; set => StateName = value; }

        /// <summary>
        /// City name. Deprecated: use <see cref="CityName"/> instead.
        /// </summary>
        [Obsolete("Use CityName instead. This property will be removed in a future version.")]
        public string City { get => CityName; set => CityName = value; }

        /// <summary>
        /// Floor number or identifier within the building at the delivery address.
        /// </summary>
        public string Floor { get; set; }

        /// <summary>
        /// Apartment number or identifier within the floor at the delivery address.
        /// </summary>
        public string Apartment { get; set; }
    }
}
