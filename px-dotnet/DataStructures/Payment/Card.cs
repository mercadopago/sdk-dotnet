using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Payment
{
    public struct Card
    {
        /// <summary>
        /// Id of the card
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Last four digits of card number
        /// </summary>
        public string LastFourDigits { get; private set; }

        /// <summary>
        /// First six digit of card number
        /// </summary>
        public string FirstSixDigits { get; private set; }

        /// <summary>
        /// Card expiration year
        /// </summary>
        public int? ExpirationYear { get; set; }

        /// <summary>
        /// Card expiration month
        /// </summary>
        public int? ExpirationMonth { get; set; }

        /// <summary>
        /// Creation date of card
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Last update of data from the card
        /// </summary>
        public DateTime? DateLastUpdated { get; set; }

        /// <summary>
        /// Card's owner data
        /// </summary>
        public CardHolder? CardHolder { get; set; }
    }
}
