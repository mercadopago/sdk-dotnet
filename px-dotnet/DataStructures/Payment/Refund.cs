using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Payment
{
    public struct Refund
    {
        /// <summary>
        /// Refund identifier
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Payment on which the return was made
        /// </summary>
        public int PaymentId { get; private set; }

        /// <summary>
        /// Amount refunded
        /// </summary>
        public decimal Amount { get; private set; }

        /// <summary>
        /// Valid JSON that can be attached to the payment 
        /// to record additional attributes of the merchant
        /// </summary>
        public JObject Metadata { get; private set; }

        /// <summary>
        /// Who made the refund
        /// </summary>
        public Source? Source { get; private set; }

        /// <summary>
        /// Date of refund
        /// </summary>
        public DateTime? CreatedDate { get; private set; }

        /// <summary>
        /// Refund identifier given by the card processor
        /// </summary>
        public string UniqueSequenceNumber { get; private set; }
    }
}
