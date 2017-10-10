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
        public Customer Save()
        {
            return (Customer)ProcessMethod<Customer>("Save", WITHOUT_CACHE);
        }

        [PUTEndpoint("/v1/customers/:id")]
        public Customer Update()
        {
            return (Customer)ProcessMethod<Customer>("Update", WITHOUT_CACHE);
        }

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
        private Phone _phone;
        private Identification _identification;
        private string _default_address;
        private DefaultAddress _address;
        private DateTime? _date_registered;
        private string _description;
        private DateTime? _date_created;
        private DateTime? _date_last_updated;
        private JObject _metadata;
        private string _default_card;
        private Card[] _cards;
        private Address[] _addresses;
        private bool? _live_mode;

        #endregion

        #region Accessors

        public string id
        {
            get { return _id; }
            private set { _id = value; }
        }

        public string email
        {
            get { return _email; }
            private     set { _email = value; }
        }

        public string first_name
        {
            get { return _first_name; }
            set { _first_name = value; }
        }

        public string last_name
        {
            get { return _last_name; }
            set { _last_name = value; }
        }

        public Phone phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public Identification identification
        {
            get { return _identification; }
            set { _identification = value; }
        }

        public string default_address
        {
            get { return _default_address; }
            set { _default_address = value; }
        }

        public DefaultAddress address
        {
            get { return _address; }
            set { _address = value; }
        }

        public DateTime? date_registered
        {
            get { return _date_registered; }
            set { _date_registered = value; }
        }

        public string description
        {
            get { return _description; }
            set { _description = value; }
        }

        public DateTime? date_created
        {
            get { return _date_created; }
            private set { _date_created = value; }
        }

        public DateTime? date_last_updated
        {
            get { return _date_last_updated; }
            private set { _date_last_updated = value; }
        }

        public JObject metadata
        {
            get { return _metadata; }
            set { _metadata = value; }
        }

        public string default_card
        {
            get { return _default_card; }
            set { _default_card = value; }
        }

        public Card[] cards
        {
            get { return _cards; }
            private set { _cards = value; }
        }

        public Address[] addresses
        {
            get { return _addresses; }
            private set { _addresses = value; }
        }

        public bool? live_mode
        {
            get { return _live_mode; }
            private set { _live_mode = value; }
        }

        #endregion
    }
}
