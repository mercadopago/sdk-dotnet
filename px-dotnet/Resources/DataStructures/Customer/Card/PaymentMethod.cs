
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources.DataStructures.Customer.Card
{
    public class PaymentMethod
    {
        #region Properties

        private string id;
        private string name;
        private string paymentTypeId;
        private string thumbnail;
        private string secureThumbnail;      

        #endregion

        #region Accessors

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string PaymentTypeId
        {
            get { return paymentTypeId; }
            set { paymentTypeId = value; }
        }

        public string Thumbnail
        {
            get { return thumbnail; }
            set { thumbnail = value; }
        }

        public string SecureThumbnail
        {
            get { return secureThumbnail; }
            set { secureThumbnail = value; }
        }

        #endregion
    }
}
