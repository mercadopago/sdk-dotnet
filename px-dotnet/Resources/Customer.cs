using MercadoPago.Resources;
using MercadoPago.DataStructures.Customer;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago
{    
    public class Customer : MPBase
    {
        #region Actions
        /// <summary>
        /// Get all customers acoording to specific filters
        /// </summary>
        [GETEndpoint("/v1/customers/search")]
        public static List<Customer> Search(Dictionary<string, string> filters)
        {
            return Search(filters, WITHOUT_CACHE);
        }
        /// <summary>
        /// Get all customers acoording to specific filters
        /// </summary>
        [GETEndpoint("/v1/customers/search")]
        public static List<Customer> Search(Dictionary<string, string> filters, bool useCache)
        {
            return (List<Customer>)ProcessMethodBulk<Customer>(typeof(Customer), "Search", filters, useCache);
        } 
        /// <summary>
        /// Find a customer by ID.
        /// </summary>
        /// <param name="id">Customer ID.</param>
        /// <param name="useCache">Cache configuration.</param>
        /// <returns>Searched customer.</returns>
        [GETEndpoint("/v1/customers/:id")]
        public static Customer FindById(string id, bool useCache)
        {
            return (Customer)ProcessMethod<Customer>("FindById", id, useCache);
        }
        /// <summary>
        /// Find a customer by ID.
        /// </summary>
        [GETEndpoint("/v1/customers/:id")]
        public static Customer FindById(String id)
        {
            return FindById(id, WITHOUT_CACHE);
        }
        /// <summary>
        /// Save a new customer
        /// </summary>
        [POSTEndpoint("/v1/customers")]
        public Customer Save()
        {
            return (Customer)ProcessMethod<Customer>("Save", WITHOUT_CACHE);
        }
        /// <summary>
        /// Update editable properties
        /// </summary>
        [PUTEndpoint("/v1/customers/:id")]
        public Customer Update()
        {
            return (Customer)ProcessMethod<Customer>("Update", WITHOUT_CACHE);
        }
        /// <summary>
        /// Remove a customer
        /// </summary>
        [DELETEEndpoint("/v1/customers/:id")]
        public Customer Delete()
        {
            return (Customer)ProcessMethod<Customer>("Delete", WITHOUT_CACHE);
        } 
        #endregion

        #region Properties 
        private string _id;
        private string _email;
        private string _first_name;
        private string _last_name;
        private Phone? _phone;
        private Identification? _identification;
        private string _default_address;
        private Address? _address;
        private DateTime? _date_registered;
        private string _description;
        private DateTime? _date_created;
        private DateTime? _date_last_updated;
        private JObject _metadata;
        private string _default_card;
        private List<Card> _cards = new List<Card>();
        private List<CustomerAddress> _addresses = new List<CustomerAddress>();
        private bool? _live_mode; 
        #endregion

        #region Accessors
        /// <summary>
        /// Customer ID
        /// </summary>
        public string Id { 
            get => _id; 
            set => _id = value; 
        }
        /// <summary>
        /// Customer's email
        /// </summary>
        public string Email { 
            get => _email; 
            set => _email = value; 
        }
        /// <summary>
        /// Customer's name
        /// </summary>
        public string FirstName { 
            get => _first_name; 
            set => _first_name = value; 
        }
        /// <summary>
        /// Customer's last name
        /// </summary>
        public string LastName { 
            get => _last_name; 
            set => _last_name = value; 
        }
        /// <summary>
        /// Customer phone's information
        /// </summary>
        public Phone? Phone { get => _phone; set => _phone = value; }
        /// <summary>
        /// Customer identification's information
        /// </summary>
        public Identification? Identification { get => _identification; set => _identification = value; }
        /// <summary>
        /// Customer's default address
        /// </summary>
        public string DefaultAddress { get => _default_address; set => _default_address = value; }
        /// <summary>
        /// Default address's information
        /// </summary>
        public Address? Address { get => _address; set => _address = value; }
        /// <summary>
        /// Customer's registration date
        /// </summary>
        public DateTime? DateRegistered { get => _date_registered; set => _date_registered = value; }
        /// <summary>
        /// Customer's description
        /// </summary>
        public string Description { get => _description; set => _description = value; }
        /// <summary>
        /// Customer's date created
        /// </summary>
        public DateTime? DateCreated { get => _date_created; set => _date_created = value; }
        /// <summary>
        /// Last modified date
        /// </summary>
        public DateTime? DateLastUpdated { get => _date_last_updated; set => _date_last_updated = value; }
        /// <summary>
        /// Customer's metadata
        /// </summary>
        public JObject Metadata { get => _metadata; set => _metadata = value; }
        /// <summary>
        /// Customer's default card
        /// </summary>
        public string Default_card { get => _default_card; set => _default_card = value; }
        /// <summary>
        /// Customer's cards
        /// </summary>
        public List<Card> Cards { get => _cards; set => _cards = value; }
        /// <summary>
        /// Customer's addresses
        /// </summary>
        public List<CustomerAddress> Addresses { get => _addresses; set => _addresses = value; }
        /// <summary>
        /// Whether the customers will be in sandbox or in production mode
        /// </summary>
        public bool? Live_mode { get => _live_mode; set => _live_mode = value; }
        #endregion
    }
}
