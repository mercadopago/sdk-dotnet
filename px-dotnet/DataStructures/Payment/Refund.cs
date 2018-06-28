using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Payment
{
    public struct Refund
    {
        #region Properties 
        private int _id;
        private int _payment_id;
        private decimal _amount;
        private JObject _metadata;
        private Source? _source;
        private DateTime? _created_date;
        private string _unique_sequence_number;
        #endregion

        #region Accessors
        /// <summary>
        /// Refund identifier
        /// </summary>
        public int Id { 
            get { return  _id; }  
            private set { _id = value; } 
        }
        /// <summary>
        /// Payment on which the return was made
        /// </summary>
        public int PaymentId { 
            get { return  _payment_id; }  
            private set { _payment_id = value; } 
        }
        /// <summary>
        /// Amount refunded
        /// </summary>
        public decimal Amount {
            get { return  _amount; }  
            private set { _amount = value; } 
        }
        /// <summary>
        /// Valid JSON that can be attached to the payment 
        /// to record additional attributes of the merchant
        /// </summary>
        public JObject Metadata { 
            get { return  _metadata; }
            private set { _metadata = value; } 
        }
        /// <summary>
        /// Who made the refund
        /// </summary>
        public Source? Source { 
            get { return  _source; } 
            private set { _source = value; } 
        }
        /// <summary>
        /// Date of refund
        /// </summary>
        public DateTime? CreatedDate { 
            get { return  _created_date; } 
            private set { _created_date = value; } 
        }
        /// <summary>
        /// Refund identifier given by the card processor
        /// </summary>
        public string UniqueSequenceNumber { 
            get { return  _unique_sequence_number; } 
            private set { _unique_sequence_number = value; } 
        }
        #endregion
    }
}
