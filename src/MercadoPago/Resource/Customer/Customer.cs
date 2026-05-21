namespace MercadoPago.Resource.Customer
{
    using System;
    using System.Collections.Generic;
    using MercadoPago.Http;
    using MercadoPago.Resource.Common;

    /// <summary>
    /// Represents a customer stored in MercadoPago, returned by the Customers
    /// API. Contains personal data, saved cards, addresses, and identification
    /// information. Use <see cref="Client.Customer.CustomerClient"/> to create,
    /// retrieve, update, and search customers.
    /// </summary>
    /// <remarks>
    /// For more information, access
    /// <a href="https://www.mercadopago.com/developers/en/reference/online-payments/checkout-api/customers/create-customer/post">here</a>.
    /// </remarks>
    public class Customer : IResource
    {
        /// <summary>
        /// Unique customer identifier assigned by MercadoPago.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Customer's email address. Used as the primary key when searching
        /// for existing customers.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Customer's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Customer's last name (surname).
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Customer's phone contact information.
        /// </summary>
        public Phone Phone { get; set; }

        /// <summary>
        /// Customer's personal identification document (e.g. CPF, DNI).
        /// </summary>
        public Identification Identification { get; set; }

        /// <summary>
        /// Identifier of the customer's default address from the
        /// <see cref="Addresses"/> collection.
        /// </summary>
        public string DefaultAddress { get; set; }

        /// <summary>
        /// Inline default address details for the customer.
        /// </summary>
        public CustomerDefaultAddress Address { get; set; }

        /// <summary>
        /// Date when the customer registered in your platform. This is a
        /// value you supply, not the MercadoPago creation date.
        /// </summary>
        public DateTime? DateRegistred { get; set; }

        /// <summary>
        /// Free-text description or notes about the customer.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Date and time when MercadoPago created this customer record.
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Date and time of the last update to this customer record.
        /// </summary>
        public DateTime? DateLastUpdated { get; set; }

        /// <summary>
        /// Custom key-value metadata attached to the customer. You can store
        /// any additional information relevant to your integration.
        /// </summary>
        public IDictionary<string, object> Metadata { get; set; }

        /// <summary>
        /// Identifier of the customer's default card from the
        /// <see cref="Cards"/> collection.
        /// </summary>
        public string DefaultCard { get; set; }

        /// <summary>
        /// List of payment cards saved for this customer. Manage cards via
        /// <see cref="Client.Customer.CustomerCardClient"/>.
        /// </summary>
        public IList<CustomerCard> Cards { get; set; }

        /// <summary>
        /// List of addresses associated with this customer.
        /// </summary>
        public IList<CustomerAddress> Addresses { get; set; }

        /// <summary>
        /// Indicates whether this customer exists in production mode
        /// (<c>true</c>) or sandbox mode (<c>false</c>).
        /// </summary>
        public bool? LiveMode { get; set; }

        /// <summary>
        /// Raw HTTP response returned by the MercadoPago API for the request
        /// that produced this resource.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
