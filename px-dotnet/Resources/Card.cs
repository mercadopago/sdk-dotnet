using System;
using System.Collections.Generic;
using MercadoPago.DataStructures.Customer.Card;

namespace MercadoPago.Resources
{
    public sealed class Card : Resource<Card>
    {
        #region Actions 
       
        public static List<Card> All(string customerId, bool useCache = false) => 
            GetList($"/v1/customers/{customerId}/cards", useCache);

        public static Card FindById(string customerId, string id, bool useCache = false) => 
            Get($"/v1/customers/{customerId}/cards/{id}", useCache);

        public Card Save() => Post($"/v1/customers/{CustomerId}/cards/");

        public Card Update() => Put($"/v1/customers/{CustomerId}/cards/{Id}");

        public Card Delete() => Delete($"/v1/customers/{CustomerId}/cards/{Id}");

        #endregion

        #region Properties  

        /// <summary>
        /// Card ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Customer ID
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Card's expiration month
        /// </summary>
        public int? ExpirationMonth { get; set; }

        /// <summary>
        /// Card's expiration year
        /// </summary>
        public int? ExpirationYear { get; set; }

        /// <summary>
        /// Card's first six digits
        /// </summary>
        public string FirstSixDigits { get; set; }

        /// <summary>
        /// Card's last four digits
        /// </summary>
        public string LastFourDigits { get; set; }

        /// <summary>
        /// Payment method information
        /// </summary>
        public CardPaymentMethod? PaymentMethod { get; set; }

        /// <summary>
        /// Security code information
        /// </summary>
        public SecurityCode? SecurityCode { get; set; }

        /// <summary>
        /// Issuer information
        /// </summary>
        public Issuer? Issuer { get; set; }

        /// <summary>
        /// Card holder information
        /// </summary>
        public CardHolder? CardHolder { get; set; }

        /// <summary>
        /// Card's date created
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Card's last modified date
        /// </summary>
        public DateTime? DateLastUpdated { get; set; }

        /// <summary>
        /// Card Token identifier
        /// </summary>
        public string Token { get; set; }

        #endregion
    }
}