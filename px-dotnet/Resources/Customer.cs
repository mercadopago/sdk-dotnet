using MercadoPago.Resources;
using MercadoPago.DataStructures.Customer;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago
{    
    /// <summary>
    /// This class allows you to store customers data safely to improve the shopping experience.
    /// This will allow your customer to complete their purchases much faster and easily when used in conjunction with the Cards class.
    /// </summary>
    public class Customer : MPBase
    {
        #region Actions
        /// <summary>
        /// Search the customers acoording to specific filters.
        /// </summary>
        /// <param name="filters">Search filters.</param>
        /// <returns>A list of customers.</returns>
        public static List<Customer> Search(Dictionary<string, string> filters)
        {
            return Search(filters, WITHOUT_CACHE, null);
        }

        /// <summary>
        /// Search the customers acoording to specific filters.
        /// </summary>
        /// <param name="filters">Search filters.</param>
        /// <param name="useCache">Use cache or not.</param>
        /// <param name="requestOptions">Request options.</param>
        /// <returns>A list of customers.</returns>
        [GETEndpoint("/v1/customers/search")]
        public static List<Customer> Search(Dictionary<string, string> filters, bool useCache, MPRequestOptions requestOptions)
        {
            return (List<Customer>)ProcessMethodBulk<Customer>(typeof(Customer), "Search", filters, useCache, requestOptions);
        } 

        /// <summary>
        /// Find a customer by your ID.
        /// </summary>
        /// <param name="id">Customer ID.</param>
        /// <param name="useCache">Cache configuration.</param>
        /// <param name="requestOptions">Request options.</param>
        /// <returns>The searched customer data.</returns>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/customers/_customers_id/get/">here</a>.
        /// </remarks>
        [GETEndpoint("/v1/customers/:id")]
        public static Customer FindById(string id, bool useCache, MPRequestOptions requestOptions)
        {
            return (Customer)ProcessMethod<Customer>("FindById", id, useCache, requestOptions);
        }

        /// <summary>
        /// Find a customer by your ID.
        /// </summary>
        /// <param name="id">Customer ID.</param>
        /// <returns>The searched customer data.</returns>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/customers/_customers_id/get/">here</a>.
        /// </remarks>
        public static Customer FindById(string id)
        {
            return FindById(id, WITHOUT_CACHE, null);
        }

        /// <summary>
        /// Saves the new customer.
        /// </summary>
        /// <returns>The saved customer data.</returns>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/customers/_customers/post/">here</a>.
        /// </remarks>
        public Customer Save()
        {
            return Save(null);
        }

        /// <summary>
        /// Saves the new customer.
        /// </summary>
        /// <param name="requestOptions">Request options.</param>
        /// <returns>The saved customer data.</returns>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/customers/_customers/post/">here</a>.
        /// </remarks>
        [POSTEndpoint("/v1/customers")]
        public Customer Save(MPRequestOptions requestOptions)
        {
            return (Customer)ProcessMethod<Customer>("Save", WITHOUT_CACHE, requestOptions);
        }

        /// <summary>
        /// Updates the customer editable properties.
        /// </summary>
        /// <returns>The updated customer data.</returns>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/customers/_customers_id/put/">here</a>.
        /// </remarks>
        public Customer Update()
        {
            return Update(null);
        }

        /// <summary>
        /// Updates the customer editable properties.
        /// </summary>
        /// <param name="requestOptions">Request options.</param>
        /// <returns>The updated customer data.</returns>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/customers/_customers_id/put/">here</a>.
        /// </remarks>
        [PUTEndpoint("/v1/customers/:id")]
        public Customer Update(MPRequestOptions requestOptions)
        {
            return (Customer)ProcessMethod<Customer>("Update", WITHOUT_CACHE, requestOptions);
        }

        /// <summary>
        /// Deletes the customer.
        /// </summary>
        /// <returns>The deleted customer data.</returns>
        public Customer Delete()
        {
            return Delete(null);
        }

        /// <summary>
        /// Deletes the customer.
        /// </summary>
        /// <param name="requestOptions">Request options.</param>
        /// <returns>The deleted customer data.</returns>
        [DELETEEndpoint("/v1/customers/:id")]
        public Customer Delete(MPRequestOptions requestOptions)
        {
            return (Customer)ProcessMethod<Customer>("Delete", WITHOUT_CACHE, requestOptions);
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
            get {  return _id; } 
            set {  _id = value; } 
        }
        /// <summary>
        /// Customer's email
        /// </summary>
        public string Email { 
            get {  return _email; } 
            set {  _email = value; } 
        }
        /// <summary>
        /// Customer's name
        /// </summary>
        public string FirstName { 
            get {  return _first_name; } 
            set {  _first_name = value; } 
        }
        /// <summary>
        /// Customer's last name
        /// </summary>
        public string LastName { 
            get {  return _last_name; } 
            set {  _last_name = value; } 
        }
        /// <summary>
        /// Customer phone's information
        /// </summary>
        public Phone? Phone { get {  return _phone; } set {  _phone = value; } }
        /// <summary>
        /// Customer identification's information
        /// </summary>
        public Identification? Identification { get {  return _identification; } set {  _identification = value; } }
        /// <summary>
        /// Customer's default address
        /// </summary>
        public string DefaultAddress { get {  return _default_address; } set {  _default_address = value; } }
        /// <summary>
        /// Default address's information
        /// </summary>
        public Address? Address { get { return _address; } set {  _address = value; } }
        /// <summary>
        /// Customer's registration date
        /// </summary>
        public DateTime? DateRegistered { get { return _date_registered; } set {  _date_registered = value; } }
        /// <summary>
        /// Customer's description
        /// </summary>
        public string Description { get { return _description; } set {  _description = value; } }
        /// <summary>
        /// Customer's date created
        /// </summary>
        public DateTime? DateCreated { get { return _date_created; } set {  _date_created = value; } }
        /// <summary>
        /// Last modified date
        /// </summary>
        public DateTime? DateLastUpdated { get { return _date_last_updated; } set {  _date_last_updated = value; } }
        /// <summary>
        /// Customer's metadata
        /// </summary>
        public JObject Metadata { get { return _metadata; } set {  _metadata = value; } }
        /// <summary>
        /// Customer's default card
        /// </summary>
        public string DefaultCard { get { return _default_card; } set {  _default_card = value; } }
        /// <summary>
        /// Customer's cards
        /// </summary>
        public List<Card> Cards { get { return _cards; } set {  _cards = value; } }
        /// <summary>
        /// Customer's addresses
        /// </summary>
        public List<CustomerAddress> Addresses { get { return _addresses; } set {  _addresses = value; } }
        /// <summary>
        /// Whether the customers will be in sandbox or in production mode
        /// </summary>
        public bool? LiveMode { get { return _live_mode; } set {  _live_mode = value; } }
        #endregion
    }
}
