using System;
using System.Collections.Generic;
using MercadoPago.Client.Common;

namespace MercadoPago.Client.Customer
{
    /// <summary>
    /// Request DTO for creating or updating a customer in the MercadoPago Customers API.
    /// Used with <see cref="CustomerClient.CreateAsync"/> and <see cref="CustomerClient.UpdateAsync"/>.
    /// When updating, only the properties that are set will be modified; unset properties remain unchanged.
    /// </summary>
    public class CustomerRequest
    {
        /// <summary>
        /// Customer's email address. Used as the primary identifier when searching for existing customers.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Customer's first (given) name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Customer's last (family) name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Customer's phone contact information.
        /// </summary>
        public PhoneRequest Phone { get; set; }

        /// <summary>
        /// Customer's personal identification document (e.g., CPF, DNI).
        /// See <see cref="IdentificationRequest"/> for accepted types and formats.
        /// </summary>
        public IdentificationRequest Identification { get; set; }

        /// <summary>
        /// Identifier of the customer's default address. This references an address ID
        /// previously returned by the API.
        /// </summary>
        public string DefaultAddress { get; set; }

        /// <summary>
        /// Identifier of the customer's default saved card. This references a card ID
        /// previously returned when saving a card via <see cref="CustomerCardClient"/>.
        /// </summary>
        public string DefaultCard { get; set; }

        /// <summary>
        /// Full default address details for the customer.
        /// See <see cref="CustomerDefaultAddressRequest"/> for the expected fields.
        /// </summary>
        public CustomerDefaultAddressRequest Address { get; set; }

        /// <summary>
        /// Date when the customer registered on the integrator's platform.
        /// Useful for risk analysis and fraud prevention.
        /// </summary>
        public DateTime? DateRegistred { get; set; }

        /// <summary>
        /// Free-text description or notes about the customer, stored for the integrator's reference.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Arbitrary key-value metadata attached to the customer resource.
        /// Can be used to store integrator-specific data such as internal IDs or tags.
        /// </summary>
        public IDictionary<string, object> Metadata { get; set; }
    }
}
