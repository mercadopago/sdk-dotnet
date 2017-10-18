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
        private int _expirationYear;
        private int _expirationMonth;
        private DateTime _dateCreated;
        private DateTime _dateLastUpdated;
        private CardHolder _cardHolder;

        public string Id { get => _id; set => _id = value; } 

        public string LastFourDigits { 
            get => _lastFourDigits;
            private set => _lastFourDigits = value; 
        }
        public string FirstSixDigits { 
            get => _firstSixDigits; 
            private set => _firstSixDigits = value; 
        }

        public int ExpirationYear { get => _expirationYear; set => _expirationYear = value; }
        public int ExpirationMonth { get => _expirationMonth; set => _expirationMonth = value; }
        public DateTime DateCreated { get => _dateCreated; set => _dateCreated = value; }
        public DateTime DateLastUpdated { get => _dateLastUpdated; set => _dateLastUpdated = value; }
        public CardHolder CardHolder { get => _cardHolder; set => _cardHolder = value; }



        #endregion
    }
}
