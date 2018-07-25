using System;
using System.Collections.Generic;
using System.Linq;
using MercadoPago.DataStructures.Customer;
using MercadoPago.Resources;
using Newtonsoft.Json.Linq;

namespace MercadoPago
{
    public sealed class Customer : Resource<Customer>
    {
        #region Actions

        /// <summary>
        /// Get all customers acoording to specific filters
        /// </summary>
        public static List<Customer> Search(Dictionary<string, string> filters, bool useCache = false) => 
            GetList("/v1/customers/search", useCache, filters);

        public static IQueryable<Customer> Query(bool useCache = false) =>
            CreateQuery("/v1/customers/search", useCache);

        /// <summary>
        /// Find a customer by ID.
        /// </summary>
        /// <param name="id">Customer ID.</param>
        /// <param name="useCache">Cache configuration.</param>
        /// <returns>Searched customer.</returns>
        public static Customer FindById(string id, bool useCache = false) => Get($"/v1/customers/{id}", useCache);

        /// <summary>
        /// Save a new customer
        /// </summary>
        public Customer Save() => Post("/v1/customers");

        /// <summary>
        /// Update editable properties
        /// </summary>
        public Customer Update() => Put($"/v1/customers/{Id}");

        /// <summary>
        /// Remove a customer
        /// </summary>
        public Customer Delete() => Delete($"/v1/customers/{Id}");
        
        #endregion

        #region Properties 

        /// <summary>
        /// Customer ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Customer's email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Customer's name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Customer's last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Customer phone's information
        /// </summary>
        public Phone? Phone { get; set; }

        /// <summary>
        /// Customer identification's information
        /// </summary>
        public Identification? Identification { get; set; }

        /// <summary>
        /// Customer's default address
        /// </summary>
        public string DefaultAddress { get; set; }

        /// <summary>
        /// Default address's information
        /// </summary>
        public Address? Address { get; set; }

        /// <summary>
        /// Customer's registration date
        /// </summary>
        public DateTime? DateRegistered { get; set; }

        /// <summary>
        /// Customer's description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Customer's date created
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Last modified date
        /// </summary>
        public DateTime? DateLastUpdated { get; set; }

        /// <summary>
        /// Customer's metadata
        /// </summary>
        public JObject Metadata { get; set; }

        /// <summary>
        /// Customer's default card
        /// </summary>
        public string DefaultCard { get; set; }

        /// <summary>
        /// Customer's cards
        /// </summary>
        public List<Card> Cards { get; set; } = new List<Card>();

        /// <summary>
        /// Customer's addresses
        /// </summary>
        public List<CustomerAddress> Addresses { get; set; } = new List<CustomerAddress>();

        /// <summary>
        /// Whether the customers will be in sandbox or in production mode
        /// </summary>
        public bool? LiveMode { get; set; }

        #endregion
    }
}