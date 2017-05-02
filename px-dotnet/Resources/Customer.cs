using MercadoPago.Resources;
using MercadoPago.Resources.DataStructures.Customer;
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

        public static List<Customer> Search()
        {
            return Search(WITHOUT_CACHE);
        }

        [GETEndpoint("/v1/customers/search")]
        public static List<Customer> Search(Boolean useCache)
        {
            return (List<Customer>)ProcessMethodBulk<Customer>(typeof(Customer), "Search", useCache);
        }

        /// <summary>
        /// Loads specified customer by ID.
        /// </summary>
        /// <param name="id">Customer ID.</param>
        /// <param name="useCache">Cache configuration.</param>
        /// <returns>Searched customer.</returns>
        [GETEndpoint("/v1/customers/:id")]
        public static Customer Load(string id, bool useCache)
        {
            return (Customer)ProcessMethod<Customer>("Load", id, useCache);
        }

        public static Customer Load(String id)
        {
            return Load(id, WITHOUT_CACHE);
        }

        [POSTEndpoint("/v1/customers")]
        public Customer Create()
        {
            return (Customer)ProcessMethod<Customer>("Create", WITHOUT_CACHE);
        }

        [PUTEndpoint("/v1/customers/:id")]
        public Customer Update()
        {
            return (Customer)ProcessMethod<Customer>("Update", WITHOUT_CACHE);
        }

        [DELETEEndpoint("/v1/customers/:id")]
        public Customer Delete()
        {
            return (Customer)ProcessMethod("Delete", WITHOUT_CACHE);
        }

        #endregion

        #region Properties

        private string id;
        private string email;
        private string first_name;
        private string last_name;
        private Phone phone;
        private Identification identification;
        private string default_address;
        private DefaultAddress address;
        private DateTime? date_registered;
        private string description;
        private DateTime? date_created;
        private DateTime? date_last_updated;
        private JObject metadata;
        private string default_card;
        private List<Card> cards;
        private List<Address> addresses;
        private bool? live_mode;

        #endregion

        #region Accessors

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string FirstName
        {
            get { return first_name; }
            set { last_name = value; }
        }

        public string LastName
        {
            get { return last_name; }
            set { last_name = value; }
        }

        public Phone Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public Identification Identification
        {
            get { return identification; }
            set { identification = value; }
        }

        public string DefaultAddress
        {
            get { return default_address; }
            set { default_address = value; }
        }

        public DefaultAddress Address
        {
            get { return address; }
            set { address = value; }
        }

        public DateTime? DateRegistered
        {
            get { return date_registered; }
            set { date_registered = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public DateTime? DateCreated
        {
            get { return date_created; }
            set { date_created = value; }
        }

        public DateTime? DateLastUpdated
        {
            get { return date_last_updated; }
            set { date_last_updated = value; }
        }

        public JObject Metadata
        {
            get { return metadata; }
            set { metadata = value; }
        }

        public string DefaultCard
        {
            get { return default_card; }
            set { default_card = value; }
        }

        public List<Card> Cards
        {
            get { return cards; }
            set { cards = value; }
        }

        public List<Address> Addresses
        {
            get { return addresses; }
            set { addresses = value; }
        }

        public bool? LiveMode
        {
            get { return live_mode; }
            set { live_mode = value; }
        }

        #endregion
    }
}
