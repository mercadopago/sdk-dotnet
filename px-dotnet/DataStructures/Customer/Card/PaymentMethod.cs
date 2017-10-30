
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Customer.Card
{
    public struct PaymentMethod
    {
        #region Properties
        private string _id;
        private string _name;
        private string _payment_type_id;
        private string _thumbnail;
        private string _secure_thumbnail;
        #endregion

        #region Accessors
        /// <summary>
        /// Payment method ID
        /// </summary>
        public string Id { 
            get => _id; 
            set => _id = value; 
        }
        /// <summary>
        /// Payment method name
        /// </summary>
        public string Name { 
            get => _name; 
            set => _name = value; 
        }
        /// <summary>
        /// Payment method type
        /// </summary>
        public string PaymentTypeId { 
            get => _payment_type_id; 
            set => _payment_type_id = value; 
        }
        /// <summary>
        /// Payment method thumbnail
        /// </summary>
        public string Thumbnail { 
            get => _thumbnail; 
            set => _thumbnail = value; 
        }
        /// <summary>
        /// Payment method secure thumbnail
        /// </summary>
        public string SecureThumbnail { 
            get => _secure_thumbnail; 
            set => _secure_thumbnail = value; 
        }
        #endregion
    }
}
