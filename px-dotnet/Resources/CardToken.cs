using System;

namespace MercadoPago.Resources
{
    public class CardToken : MPBase
    {
        #region Actions

        public CardToken Save()
        {
            return Save(null);
        }

        [POSTEndpoint("/v1/card_tokens")]
        public CardToken Save(MPRequestOptions requestOptions)
        {
            return (CardToken)ProcessMethod<CardToken>("Save", WITHOUT_CACHE, requestOptions);
        }

        public static CardToken FindById(string id)
        {
            return FindById(id, WITHOUT_CACHE, null);
        }

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

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string PublicKey
        {
            get { return publicKey; }
            set { publicKey = value; }
        }

        public string CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }

        public string CardId
        {
            get { return cardId; }
            set { cardId = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public DateTime? DateCreated
        {
            get { return dateCreated; }
            set { dateCreated = value; }
        }

        public DateTime? DateLastUpdate
        {
            get { return dateLastUpdate; }
            set { dateLastUpdate = value; }
        }

        public DateTime? DateDue
        {
            get { return dateDue; }
            set { dateDue = value; }
        }

        public bool? LuhnValidation
        {
            get { return luhnValidation; }
            set { luhnValidation = value; }
        }

        public bool? LineMode
        {
            get { return lineMode; }
            set { lineMode = value; }
        }

        public bool? RequireEsc
        {
            get { return requireEsc; }
            set { requireEsc = value; }
        }

        public string SecurityCode
        {
            get { return securityCode; }
            set { securityCode = value; }
        }
    }
}