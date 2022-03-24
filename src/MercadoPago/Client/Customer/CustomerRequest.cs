using System;
using System.Collections.Generic;
using MercadoPago.Client.Common;

namespace MercadoPago.Client.Customer
{
    /// <summary>
    /// Parameters to create/update a customer.
    /// </summary>
    public class CustomerRequest
    {
        /// <summary>
        /// Customer's email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Customer's name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Customer's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Customer's phone.
        /// </summary>
        public PhoneRequest Phone { get; set; }

        /// <summary>
        /// Customer's identification.
        /// </summary>
        public IdentificationRequest Identification { get; set; }

        /// <summary>
        /// Customer's default address.
        /// </summary>
        public string DefaultAddress { get; set; }

        /// <summary>
        /// Customer's default card.
        /// </summary>
        public string DefaultCard { get; set; }

        /// <summary>
        /// Default address information.
        /// </summary>
        public CustomerDefaultAddressRequest Address { get; set; }

        /// <summary>
        /// Customer's registration date.
        /// </summary>
        public DateTime? DateRegistred { get; set; }

        /// <summary>
        /// Customer's description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Metadata.
        /// </summary>
        public IDictionary<string, object> Metadata { get; set; }
    }
}
