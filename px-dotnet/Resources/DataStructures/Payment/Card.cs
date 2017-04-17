using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources.DataStructures.Payment
{
    public class Card
    {
        #region Properties

        private int number;
        private string lastFourDigits;
        private string firstSixDigits;
        private int expirationYear;
        private int expirationMonth;
        private DateTime dateCreated;
        private DateTime dateLastUpdated;
        private CardHolder cardHolder;

        public int Number
        {
            get { return number; }            
        }

        

        public string LastFourDigits
        {
            get { return lastFourDigits; }            
        }

        

        public string FirstSixDigits
        {
            get { return firstSixDigits; }            
        }

        

        public int ExpirationYear
        {
            get { return expirationYear; }            
        }

        

        public int ExpirationMonth
        {
            get { return expirationMonth; }            
        }

        

        public DateTime DateCreated
        {
            get { return dateCreated; }            
        }

        

        public DateTime DateLastUpdated
        {
            get { return dateLastUpdated; }            
        }
        

        public CardHolder CardHolder
        {
            get { return cardHolder; }            
        }

        #endregion
    }
}
