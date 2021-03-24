using System;
namespace MercadoPago.Resource.Customer
{
    /// <summary>
    /// Custommer's address.
    /// </summary>
    public class CustomerAddress
    {
        /// <summary>
        /// Address ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Phone number.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Address name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Floor.
        /// </summary>
        public string Floor { get; set; }

        /// <summary>
        /// Apartment.
        /// </summary>
        public string Apartment { get; set; }

        /// <summary>
        /// Street name.
        /// </summary>
        public string StreetName { get; set; }

        /// <summary>
        /// Street number.
        /// </summary>
        public int? StreetNumer { get; set; }

        /// <summary>
        /// Postal code.
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// City information.
        /// </summary>
        public CustomerAddressCity City { get; set; }

        /// <summary>
        /// State information.
        /// </summary>
        public CustomerAddressState State { get; set; }

        /// <summary>
        /// Country information.
        /// </summary>
        public CustomerAddressCountry Country { get; set; }

        /// <summary>
        /// Neighborhood information.
        /// </summary>
        public CustomerAddressNeighborhood Neighborhood { get; set; }

        /// <summary>
        /// Municipality information.
        /// </summary>
        public CustomerAddressMunicipality Municipality { get; set; }

        /// <summary>
        /// Additional info.
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// Address date of creation.
        /// </summary>
        public DateTime? DateCreated { get; set; }
    }
}
