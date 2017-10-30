using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Payment
{
    public struct Item
    {
        #region Properties 
        private string _id;
        private string _title;
        private string _description;
        private string _picture_url;
        private string _category_id;
        private int _quantity;
        private int _unit_price; 
        #endregion

        #region Accessors 
        /// <summary>
        /// Item code
        /// </summary>
        public string Id { 
            get => _id; 
            set => _id = value; 
        }  
        /// <summary>
        /// Item name
        /// </summary>
        public string Title { 
            get => _title; 
            set => _title = value;
        }
        /// <summary>
        /// Long item description
        /// </summary>
        public string Description { 
            get => _description; 
            set => _description = value; 
        }
        /// <summary>
        /// Image URL
        /// </summary>
        public string PictureUrl { 
            get => _picture_url; 
            set => _picture_url = value; 
        }
        /// <summary>
        /// Category of the item
        /// </summary>
        public string CategoryId { 
            get => _category_id; 
            set => _category_id = value; 
        }
        /// <summary>
        /// Item's quantity
        /// </summary>
        public int Quantity {
            get => _quantity; 
            set => _quantity = value; 
        }
        /// <summary>
        /// Unit price
        /// </summary>
        public int UnitPrice { 
            get => _unit_price; 
            set => _unit_price = value; 
        }
        #endregion
    }
}
