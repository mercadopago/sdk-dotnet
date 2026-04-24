namespace MercadoPago.Client.Preference
{
    using System;
    using MercadoPago.Client.Common;

    /// <summary>
    /// Shipping destination address for the buyer. Extends <see cref="AddressRequest"/> with
    /// additional geographic fields and apartment details used in the Checkout Pro shipping flow.
    /// </summary>
    /// <seealso cref="PreferenceShipmentsRequest"/>
    public class PreferenceReceiverAddressRequest : AddressRequest
    {
        /// <summary>
        /// Full country name of the shipping destination (e.g., <c>"Argentina"</c>, <c>"Brasil"</c>).
        /// </summary>
        public string CountryName { get; set; }

        /// <summary>
        /// State or province name of the shipping destination.
        /// </summary>
        public string StateName { get; set; }

        /// <summary>
        /// City name of the shipping destination.
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
        /// Floor number or identifier within the building.
        /// </summary>
        public string Floor { get; set; }

        /// <summary>
        /// Apartment or unit number within the building.
        /// </summary>
        public string Apartment { get; set; }
    }
}
