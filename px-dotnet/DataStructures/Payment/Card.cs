using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Payment
{
    public struct Card
    {
        #region Properties 
        private string _id;
        private string _lastFourDigits;
        private string _firstSixDigits;
        private int? _expirationYear;
        private int? _expirationMonth;
        private DateTime? _dateCreated;
        private DateTime? _dateLastUpdated;
        private CardHolder? _cardHolder;
        #endregion

        #region Accessors
        /// <summary>
        /// Id of the card
        /// </summary>
        public string Id
        {
            get { return  _id; }
            set {  _id = value; }
        }
        /// <summary>
        /// Last four digits of card number
        /// </summary>
        public string LastFourDigits
        {
            get { return  _lastFourDigits; }
            private set {  _lastFourDigits = value; }
        }
        /// <summary>
        /// First six digit of card number
        /// </summary>
        public string FirstSixDigits
        {
            get { return  _firstSixDigits; }
            private set {  _firstSixDigits = value; }
        }
        /// <summary>
        /// Card expiration year
        /// </summary>
        public int? ExpirationYear
        {
            get { return  _expirationYear; }
            set {  _expirationYear = value; }
        }
        /// <summary>
        /// Card expiration month
        /// </summary>
        public int? ExpirationMonth
        {
            get { return  _expirationMonth; }
            set {  _expirationMonth = value; }
        }
        /// <summary>
        /// Creation date of card
        /// </summary>
        public DateTime? DateCreated
        {
            get { return  _dateCreated; }
            set {  _dateCreated = value; }
        }
        /// <summary>
        /// Last update of data from the card
        /// </summary>
        public DateTime? DateLastUpdated
        {
            get { return  _dateLastUpdated; }
            set {  _dateLastUpdated = value; }
        }
        /// <summary>
        /// Card's owner data
        /// </summary>
        public CardHolder? CardHolder
        {
            get { return  _cardHolder; }
            set {  _cardHolder = value; }
        }
        #endregion
    }
}
