using System;

namespace MercadoPago.Resources
{
    /// <summary>
    /// This class will allow you to send your customers card data for Mercado Pago server and receive a token to complete the payments transactions.
    /// </summary>
    public class CardToken : MPBase
    {
        #region Actions

        /// <summary>
        /// Creates a card token.
        /// </summary>
        /// <returns>The created card token.</returns>
        public CardToken Save()
        {
            return Save(null);
        }

        /// <summary>
        /// Creates a card token.
        /// </summary>
        /// <param name="requestOptions">Request options.</param>
        /// <returns>The created card token.</returns>
        [POSTEndpoint("/v1/card_tokens")]
        public CardToken Save(MPRequestOptions requestOptions)
        {
            return (CardToken)ProcessMethod<CardToken>("Save", WITHOUT_CACHE, requestOptions);
        }

        /// <summary>
        /// Get a card token by your ID.
        /// </summary>
        /// <param name="id">Card token ID.</param>
        /// <returns>The card token.</returns>
        public static CardToken FindById(string id)
        {
            return FindById(id, WITHOUT_CACHE, null);
        }

        /// <summary>
        /// Get a card token by your ID.
        /// </summary>
        /// <param name="id">Card token ID.</param>
        /// <param name="useCache">Use cache or not.</param>
        /// <param name="requestOptions">Request options.</param>
        /// <returns>The card token.</returns>
        [GETEndpoint("/v1/card_tokens/:id")]
        public static CardToken FindById(string id, bool useCache, MPRequestOptions requestOptions)
        {            
            return (CardToken)ProcessMethod<CardToken>(typeof(CardToken), "FindById", id, useCache, requestOptions);
        }

        #endregion

        private string id;
        private string publicKey;
        private string customerId;
        private string cardId;
        private string status;
        private DateTime? dateCreated;
        private DateTime? dateLastUpdate;
        private DateTime? dateDue;
        private bool? luhnValidation;
        private bool? lineMode;
        private bool? requireEsc;
        private string securityCode;

        /// <summary>
        /// Card token ID.
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Public key.
        /// </summary>
        public string PublicKey
        {
            get { return publicKey; }
            set { publicKey = value; }
        }

        /// <summary>
        /// Customer ID.
        /// </summary>
        public string CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }

        /// <summary>
        /// Card ID.
        /// </summary>
        public string CardId
        {
            get { return cardId; }
            set { cardId = value; }
        }

        /// <summary>
        /// Status.
        /// </summary>
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        /// <summary>
        /// Date of creation.
        /// </summary>
        public DateTime? DateCreated
        {
            get { return dateCreated; }
            set { dateCreated = value; }
        }

        /// <summary>
        /// Date of last update.
        /// </summary>
        public DateTime? DateLastUpdate
        {
            get { return dateLastUpdate; }
            set { dateLastUpdate = value; }
        }

        /// <summary>
        /// Due date.
        /// </summary>
        public DateTime? DateDue
        {
            get { return dateDue; }
            set { dateDue = value; }
        }

        /// <summary>
        /// If has luhn validation.
        /// </summary>
        public bool? LuhnValidation
        {
            get { return luhnValidation; }
            set { luhnValidation = value; }
        }

        /// <summary>
        /// Live mode.
        /// </summary>
        public bool? LineMode
        {
            get { return lineMode; }
            set { lineMode = value; }
        }

        /// <summary>
        /// Require esc.
        /// </summary>
        public bool? RequireEsc
        {
            get { return requireEsc; }
            set { requireEsc = value; }
        }

        /// <summary>
        /// Security code.
        /// </summary>
        public string SecurityCode
        {
            get { return securityCode; }
            set { securityCode = value; }
        }
    }
}