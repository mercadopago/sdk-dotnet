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

        public static List<Card> LoadAll(String customerId)
        {
            return LoadAll(customerId, WITHOUT_CACHE);
        }
        
        [GETEndpoint("/v1/customers/:customer_id/cards")]
        public static List<Card> LoadAll(String customerId, Boolean useCache)
        {
            return (List<Card>)ProcessMethodBulk<Card>(typeof(Card), "LoadAll", customerId, useCache);
        }

        public static Card Load(string customerId, string id)
        {
            return Load(customerId, id, WITHOUT_CACHE);
        }

        [GETEndpoint("/v1/customers/:customer_id/cards/:id")]
        public static Card Load(string customerId, string id, bool useCache)
        {            
            return (Card)ProcessMethod<Card>(typeof(Card), "Load", customerId, id, useCache);
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

        private string token;
        private string id;
        private string customerId;
        private int expirationMonth;
        private int expirationYear;
        private string firstSixDigits;
        private string lastFourDigits;
        private PaymentMethod paymentMethod;
        private SecurityCode securityCode;
        private Issuer issuer;
        private CardHolder cardHolder;
        private DateTime? dateCreated;
        private DateTime? dateLastUpdated;

        #endregion

        #region Accessors

        public string Token
        {
            get { return token; }
            set { token = value; }
        }

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public string customer_id
        {
            get { return customerId; }
            set { customerId = value; }
        }

        public int ExpirationMonth
        {
            get { return expirationMonth; }
            set { expirationMonth = value; }
        }

        public int ExpirationYear
        {
            get { return expirationYear; }
            set { expirationYear = value; }
        }

        public string FirstSixDigits
        {
            get { return firstSixDigits; }
            set { firstSixDigits = value; }
        }

        public string LastFourDigits
        {
            get { return lastFourDigits; }
            set { lastFourDigits = value; }
        }

        public PaymentMethod PaymentMethod
        {
            get { return paymentMethod; }
            set { paymentMethod = value; }
        }

        public SecurityCode SecurityCode
        {
            get { return securityCode; }
            set { securityCode = value; }
        }

        public Issuer Issuer
        {
            get { return issuer; }
            set { issuer = value; }
        }

        public CardHolder CardHolder
        {
            get { return cardHolder; }
            set { cardHolder = value; }
        }

        public DateTime? DateCreated
        {
            get { return dateCreated; }
            set { dateCreated = value; }
        }

        public DateTime? DateLastUpdated
        {
            get { return dateLastUpdated; }
            set { dateLastUpdated = value; }
        }

        #endregion
    }
}
