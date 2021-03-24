namespace MercadoPago.Resource.Customer
{
    using System;
    using System.Collections.Generic;
    using MercadoPago.Http;
    using MercadoPago.Resource.Common;

    /// <summary>
    /// Customer resource.
    /// </summary>
    /// <remarks>
    /// For more information, access
    /// <a href="https://www.mercadopago.com/developers/en/reference/customers/resource/">here</a>.
    /// </remarks>
    public class Customer : IResource
    {
        /// <summary>
        /// Customer ID.
        /// </summary>
        public string Id { get; set; }

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
        public Phone Phone { get; set; }

        /// <summary>
        /// Customer's identification.
        /// </summary>
        public Identification Identification { get; set; }

        /// <summary>
        /// Customer's default address.
        /// </summary>
        public string DefaultAddress { get; set; }

        /// <summary>
        /// Default address information.
        /// </summary>
        public CustomerDefaultAddress Address { get; set; }

        /// <summary>
        /// Customer's registration date.
        /// </summary>
        public DateTime? DateRegistred { get; set; }

        /// <summary>
        /// Customer's description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Date of creation.
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Last modified date.
        /// </summary>
        public DateTime? DateLastUpdated { get; set; }

        /// <summary>
        /// Metadata.
        /// </summary>
        public IDictionary<string, object> Metadata { get; set; }

        /// <summary>
        /// Customer's default card.
        /// </summary>
        public string DefaultCard { get; set; }

        /// <summary>
        /// Customer's cards.
        /// </summary>
        public IList<CustomerCard> Cards { get; set; }

        /// <summary>
        /// Customer's addresses
        /// </summary>
        public IList<CustomerAddress> Addresses { get; set; }

        /// <summary>
        /// Whether the customers will be in sandbox or in production mode.
        /// </summary>
        public bool? LiveMode { get; set; }

        /// <summary>
        /// Response from API.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
