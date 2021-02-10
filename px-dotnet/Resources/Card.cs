using MercadoPago.DataStructures.Customer.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources
{
    /// <summary>
    /// The cards class is the way to store card data of your customers safely to improve the shopping experience.
    /// This will allow your customers to complete their purchases much faster and easily, since they will not have to complete their card data again.
    /// This class must be used in conjunction with the Customer class.
    /// </summary>
    public class Card : MPBase
    {
        #region Actions 

        /// <summary>
        /// List all cards from customer.
        /// </summary>
        /// <param name="customerId">Customer ID.</param>
        /// <returns>A list with all cards.</returns>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/cards/_customers_customer_id_cards/get/">here</a>.
        /// </remarks>
        public static List<Card> All(String customerId)
        {
            return All(customerId, WITHOUT_CACHE, null);
        }
        
        /// <summary>
        /// List all cards from customer.
        /// </summary>
        /// <param name="customerId">Customer ID.</param>
        /// <param name="useCache">Use cache or not.</param>
        /// <param name="requestOptions">Request options.</param>
        /// <returns>A list with all cards.</returns>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/cards/_customers_customer_id_cards/get/">here</a>.
        /// </remarks>
        [GETEndpoint("/v1/customers/:customer_id/cards")]
        public static List<Card> All(String customerId, bool useCache, MPRequestOptions requestOptions)
        {
            return (List<Card>)ProcessMethodBulk<Card>(typeof(Card), "All", customerId, useCache, requestOptions);
        }

        /// <summary>
        /// Find the card of a customer by ID.
        /// </summary>
        /// <param name="customerId">Customer ID.</param>
        /// <param name="id">Card ID.</param>
        /// <returns>The card.</returns>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/cards/_customers_customer_id_cards_id/get/">here</a>.
        /// </remarks>
        public static Card FindById(string customerId, string id)
        {
            return FindById(customerId, id, WITHOUT_CACHE, null);
        }

        /// <summary>
        /// Find the card of a customer by ID.
        /// </summary>
        /// <param name="customerId">Customer ID.</param>
        /// <param name="id">Card ID.</param>
        /// <param name="useCache">Use cache or not.</param>
        /// <param name="requestOptions">Request options.</param>
        /// <returns>The card.</returns>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/cards/_customers_customer_id_cards_id/get/">here</a>.
        /// </remarks>
        [GETEndpoint("/v1/customers/:customer_id/cards/:id")]
        public static Card FindById(string customerId, string id, bool useCache, MPRequestOptions requestOptions)
        {
            var pathParams = new Dictionary<string, string>();
            pathParams.Add("customer_id", customerId);
            pathParams.Add("id", id);
            return ProcessMethod<Card>(typeof(Card), null, "FindById", pathParams, useCache, requestOptions);
        }

        /// <summary>
        /// Save the card.
        /// </summary>
        /// <returns>The saved card data.</returns>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/cards/_customers_customer_id_cards/post/">here</a>.
        /// </remarks>
        public Card Save()
        {
            return Save(null);
        }

        /// <summary>
        /// Save the card.
        /// </summary>
        /// <param name="requestOptions">Request options.</param>
        /// <returns>The saved card data.</returns>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/cards/_customers_customer_id_cards/post/">here</a>.
        /// </remarks>
        [POSTEndpoint("/v1/customers/:customer_id/cards/")]
        public Card Save(MPRequestOptions requestOptions)
        {
            return (Card)ProcessMethod<Card>("Save", WITHOUT_CACHE, requestOptions);
        }

        /// <summary>
        /// Update the card.
        /// </summary>
        /// <returns>The updated card data.</returns>
        public Card Update()
        {
            return Update(null);
        }

        /// <summary>
        /// Update the card.
        /// </summary>
        /// <param name="requestOptions">Request options.</param>
        /// <returns>The updated card data.</returns>
        [PUTEndpoint("/v1/customers/:customer_id/cards/:id")]
        public Card Update(MPRequestOptions requestOptions)
        {
            return (Card)ProcessMethod<Card>("Update", WITHOUT_CACHE, requestOptions);
        }

        /// <summary>
        /// Delete the card.
        /// </summary>
        /// <returns>The deleted card data.</returns>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/cards/_customers_customer_id_cards_id/delete/">here</a>.
        /// </remarks>
        public Card Delete()
        {
            return Delete(null);
        }

        /// <summary>
        /// Delete the card.
        /// </summary>
        /// <param name="requestOptions">Request options.</param>
        /// <returns>The deleted card data.</returns>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/cards/_customers_customer_id_cards_id/delete/">here</a>.
        /// </remarks>
        [DELETEEndpoint("/v1/customers/:customer_id/cards/:id")]
        public Card Delete(MPRequestOptions requestOptions)
        {
            return (Card)ProcessMethod<Card>("Delete", WITHOUT_CACHE, requestOptions);
        }
        #endregion

        #region Properties  
        private string _id;
        private string _customer_id;
        private int? _expiration_month;
        private int? _expiration_year;
        private string _first_six_digits;
        private string _last_four_digits;
        private CardPaymentMethod? _payment_method;
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
        public string Id
        {
            get
            {
                return _id;
            } 
            set
            {
                _id = value;
            }
        }
        /// <summary>
        /// Customer ID
        /// </summary>
        public string CustomerId
        {
            get
            {
                return _customer_id;
            } 
            set
            {
                _customer_id = value;
            }
        }
        /// <summary>
        /// Card's expiration month
        /// </summary>
        public int? ExpirationMonth
        {
            get
            {
                return _expiration_month;
            }

            set
            {
                _expiration_month = value;
            }
        }
        /// <summary>
        /// Card's expiration year
        /// </summary>
        public int? ExpirationYear
        {
            get
            {
                return _expiration_year;
            }

            set
            {
                _expiration_year = value;
            }
        }
        /// <summary>
        /// Card's first six digits
        /// </summary>
        public string FirstSixDigits
        {
            get
            {
                return _first_six_digits;
            }

            set
            {
                _first_six_digits = value;
            }
        }
        /// <summary>
        /// Card's last four digits
        /// </summary>
        public string LastFourDigits
        {
            get
            {
                return _last_four_digits;
            }

            set
            {
                _last_four_digits = value;
            }
        }
        /// <summary>
        /// Payment method information
        /// </summary>
        public CardPaymentMethod? PaymentMethod
        {
            get
            {
                return _payment_method;
            }

            set
            {
                _payment_method = value;
            }
        }
        /// <summary>
        /// Security code information
        /// </summary>
        public SecurityCode? SecurityCode
        {
            get
            {
                return _security_code;
            }

            set
            {
                _security_code = value;
            }
        }
        /// <summary>
        /// Issuer information
        /// </summary>
        public Issuer? Issuer 
        {
            get
            {
                return _issuer;
            }

            set
            {
                _issuer = value;
            }
        }
        /// <summary>
        /// Card holder information
        /// </summary>
        public CardHolder? CardHolder
        {
            get
            {
                return _card_holder;
            }

            set
            {
                _card_holder = value;
            }
        }
        /// <summary>
        /// Card's date created
        /// </summary>
        public DateTime? DateCreated 
        {
            get
            {
                return _date_created;
            }

            set
            {
                _date_created = value;
            }
        }
        /// <summary>
        /// Card's last modified date
        /// </summary>
        public DateTime? DateLastUpdated 
        {
            get
            {
                return _date_last_updated;
            }

            set
            {
                _date_last_updated = value;
            }
        }
        /// <summary>
        /// Card Token identifier
        /// </summary>
        public string Token {
            get
            {
                return _token;
            }

            set
            {
                _token = value;
            }
        }
          
        #endregion
    }
}
