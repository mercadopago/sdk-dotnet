namespace MercadoPago.Client.Preference
{
    using System;
    using MercadoPago.Client.Common;

    /// <summary>
    /// Shipping address.
    /// </summary>
    public class PreferenceReceiverAddressRequest : AddressRequest
    {
        /// <summary>
        /// Country.
        /// </summary>
        public string CountryName { get; set; }

        /// <summary>
        /// State.
        /// </summary>
        public string StateName { get; set; }

        /// <summary>
        /// City.
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// Country (deprecated, use CountryName instead).
        /// </summary>
        [Obsolete("Use CountryName instead. This property will be removed in a future version.")]
        public string Country { get => CountryName; set => CountryName = value; }

        /// <summary>
        /// State (deprecated, use StateName instead).
        /// </summary>
        [Obsolete("Use StateName instead. This property will be removed in a future version.")]
        public string State { get => StateName; set => StateName = value; }

        /// <summary>
        /// City (deprecated, use CityName instead).
        /// </summary>
        [Obsolete("Use CityName instead. This property will be removed in a future version.")]
        public string City { get => CityName; set => CityName = value; }

        /// <summary>
        /// Floor.
        /// </summary>
        public string Floor { get; set; }

        /// <summary>
        /// Apartment.
        /// </summary>
        public string Apartment { get; set; }
    }
}
