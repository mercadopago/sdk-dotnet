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
        
        /// <summary>
        /// Loads specified customer by ID.
        /// </summary>
        /// <param name="id">Customer ID.</param>
        /// <param name="useCache">Cache configuration.</param>
        /// <returns>Searched customer.</returns>
        [GETEndpoint("/v1/customers/:id")]
        public static Customer Load(string id, bool useCache)
        {
            return (Customer)ProcessMethod("load", "id", useCache);
        }
        
        #endregion
        
        #region Properties

        private string id;        
        private string email;        
        private string firstName;
        private string lastName;       
        private Phone phone;        
        private Identification identification;        
        private string defaultAddress;        
        private DefaultAddress address;        
        private DateTime dateRegistered;        
        private string description;        
        private DateTime dateCreated;        
        private DateTime dateLastUpdated;        
        private JObject metadata;        
        private string defaultCard;        
        private List<Card> cards;        
        private List<Address> addresses;        
        private bool liveMode;        
        
        #endregion

        #region Accessors

        public string getId()
        {
            return id;
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
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
            get { return defaultAddress; }
            set { defaultAddress = value; }
        }

        public DefaultAddress Address
        {
            get { return address; }
            set { address = value; }
        }

        public DateTime DateRegistered
        {
            get { return dateRegistered; }
            set { dateRegistered = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public DateTime DateCreated
        {
            get { return dateCreated; }
            set { dateCreated = value; }
        }

        public DateTime DateLastUpdated
        {
            get { return dateLastUpdated; }
            set { dateLastUpdated = value; }
        }

        public JObject Metadata
        {
            get { return metadata; }
            set { metadata = value; }
        }

        public string DefaultCard
        {
            get { return defaultCard; }
            set { defaultCard = value; }
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

        public bool LiveMode
        {
            get { return liveMode; }
            set { liveMode = value; }
        }

        #endregion        
    }
}
