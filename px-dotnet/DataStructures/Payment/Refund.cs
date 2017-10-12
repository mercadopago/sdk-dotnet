using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Payment
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
        }
        
        public int PaymentId
        {
            get { return paymentId; }            
        }
       
        public decimal Amount
        {
            get { return amount; }            
        }
       
        public JObject Metadata
        {
            get { return metadata; }            
        }
       
        public Source Source
        {
            get { return source; }            
        }
        
        public DateTime CreatedDate
        {
            get { return createdDate; }            
        }
       
        public string UniqueSequenceNumber
        {
            get { return uniqueSequenceNumber; }            
        }

        #endregion
    }
}
