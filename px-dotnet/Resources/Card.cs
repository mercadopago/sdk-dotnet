using MercadoPago.DataStructures.Customer.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources
{
    public class Card : MPBase
    {
        #region Actions

        public static List<Card> All(String customerId)
        {
            return All(customerId, WITHOUT_CACHE);
        }
        
        [GETEndpoint("/v1/customers/:customer_id/cards")]
        public static List<Card> All(String customerId, bool useCache)
        {
            return (List<Card>)ProcessMethodBulk<Card>(typeof(Card), "All", customerId, useCache);
        }

        public static Card FindById(string customerId, string id)
        {
            return FindById(customerId, id, WITHOUT_CACHE);
        }

        [GETEndpoint("/v1/customers/:customer_id/cards/:id")]
        public static Card FindById(string customerId, string id, bool useCache)
        {            
            return (Card)ProcessMethod<Card>(typeof(Card), "FindById", customerId, id, useCache);
        }

        [POSTEndpoint("/v1/customers/:customer_id/cards/")]
        public Card Save()
        {
            return (Card)ProcessMethod<Card>("Save", WITHOUT_CACHE);
        }

        [PUTEndpoint("/v1/customers/:customer_id/cards/:id")]
        public Card Update()
        {
            return (Card)ProcessMethod<Card>("Update", WITHOUT_CACHE);
        }

        [DELETEEndpoint("/v1/customers/:customer_id/cards/:id")]
        public Card Delete()
        {
            return (Card)ProcessMethod("Delete", WITHOUT_CACHE);
        } 
        #endregion

        #region Properties  
        private string _id;
        private string _customer_id;
        private int? _expiration_month;
        private int? _expiration_year;
        private string _first_six_digits;
        private string _last_four_digits;
        private PaymentMethod? _payment_method;
        private SecurityCode? _security_code;
        private Issuer? _issuer;
        private CardHolder? _card_holder;
        private DateTime? _date_created;
        private DateTime? _date_last_updated;
        private string _token;
        #endregion

        #region Accessors
        /// <summary>
        /// Card ID
        /// </summary>
        public string Id { get => _id; set => _id = value; }
        /// <summary>
        /// Customer ID
        /// </summary>
        public string CustomerId { get => _customer_id; set => _customer_id = value; }
        /// <summary>
        /// Card's expiration month
        /// </summary>
        public int? ExpirationMonth { get => _expiration_month; set => _expiration_month = value; }
        /// <summary>
        /// Card's expiration year
        /// </summary>
        public int? ExpirationYear { get => _expiration_year; set => _expiration_year = value; }
        /// <summary>
        /// Card's first six digits
        /// </summary>
        public string FirstSixDigits { get => _first_six_digits; set => _first_six_digits = value; }
        /// <summary>
        /// Card's last four digits
        /// </summary>
        public string LastFourDigits { get => _last_four_digits; set => _last_four_digits = value; }
        /// <summary>
        /// Payment method information
        /// </summary>
        public PaymentMethod? PaymentMethod { get => _payment_method; set => _payment_method = value; }
        /// <summary>
        /// Security code information
        /// </summary>
        public SecurityCode? SecurityCode { get => _security_code; set => _security_code = value; }
        /// <summary>
        /// Issuer information
        /// </summary>
        public Issuer? Issuer { get => _issuer; set => _issuer = value; }
        /// <summary>
        /// Card holder information
        /// </summary>
        public CardHolder? CardHolder { get => _card_holder; set => _card_holder = value; }
        /// <summary>
        /// Card's date created
        /// </summary>
        public DateTime? DateCreated { get => _date_created; set => _date_created = value; }
        /// <summary>
        /// Card's last modified date
        /// </summary>
        public DateTime? DateLastUpdated { get => _date_last_updated; set => _date_last_updated = value; }
        /// <summary>
        /// Card Token identifier
        /// </summary>
        public string Token { get => _token; set => _token = value; }
        #endregion
    }
}
