using System;
namespace MercadoPago.Resource.Customer
{
    /// <summary>
    /// Represents a full address associated with a <see cref="Customer"/>.
    /// Includes geographic breakdown (city, state, country, neighborhood, and
    /// municipality) and is returned within the customer's
    /// <see cref="Customer.Addresses"/> collection.
    /// </summary>
    public class CustomerAddress
    {
        /// <summary>
        /// Unique identifier of this address within the customer's address list.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Contact phone number associated with this address.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// User-defined label for this address (e.g. "Home", "Office").
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Floor number or identifier within the building.
        /// </summary>
        public string Floor { get; set; }

        /// <summary>
        /// Apartment or unit identifier within the building.
        /// </summary>
        public string Apartment { get; set; }

        /// <summary>
        /// Street name component of the address.
        /// </summary>
        public string StreetName { get; set; }

        /// <summary>
        /// Street number (house or building number) of the address.
        /// </summary>
        public int? StreetNumer { get; set; }

        /// <summary>
        /// Postal / ZIP code of the address.
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// City information for this address.
        /// </summary>
        public CustomerAddressCity City { get; set; }

        /// <summary>
        /// State or province information for this address.
        /// </summary>
        public CustomerAddressState State { get; set; }

        /// <summary>
        /// Country information for this address.
        /// </summary>
        public CustomerAddressCountry Country { get; set; }

        /// <summary>
        /// Neighborhood (barrio) information for this address.
        /// </summary>
        public CustomerAddressNeighborhood Neighborhood { get; set; }

        /// <summary>
        /// Municipality (municipio) information for this address.
        /// </summary>
        public CustomerAddressMunicipality Municipality { get; set; }

        /// <summary>
        /// Free-text additional information or delivery instructions for this
        /// address.
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// Date and time when this address was created within the customer record.
        /// </summary>
        public DateTime? DateCreated { get; set; }
    }
}
