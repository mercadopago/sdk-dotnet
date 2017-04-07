using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources.DataStructures.Payment
{
    public class Refund
    {
        #region Properties

        private int id;
        private int paymentId;
        private decimal amount;
        private JObject metadata;
        private Source source;
        private DateTime createdDate;
        private string uniqueSequenceNumber;

        #endregion

        #region Accessors

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        
        public int PaymentId
        {
            get { return paymentId; }
            set { paymentId = value; }
        }
       
        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }
       
        public JObject Metadata
        {
            get { return metadata; }
            set { metadata = value; }
        }
       
        public Source Source
        {
            get { return source; }
            set { source = value; }
        }
        
        public DateTime CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; }
        }
       
        public string UniqueSequenceNumber
        {
            get { return uniqueSequenceNumber; }
            set { uniqueSequenceNumber = value; }
        }

        #endregion
    }
}
