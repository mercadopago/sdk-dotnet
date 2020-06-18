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
        private int? _quantity;
        private decimal? _unit_price;
        private Passenger? _passenger;
        private Route? _route;
        private bool _warranty;
        private DateTime? _event_date;
        #endregion

        #region Accessors 
        /// <summary>
        /// Item code
        /// </summary>
        public string Id { 
            get { return  _id; } 
            set { _id = value; } 
        }  
        /// <summary>
        /// Item name
        /// </summary>
        public string Title { 
            get { return  _title; } 
            set { _title = value; }
        }
        /// <summary>
        /// Long item description
        /// </summary>
        public string Description { 
            get { return  _description; } 
            set { _description = value; } 
        }
        /// <summary>
        /// Image URL
        /// </summary>
        public string PictureUrl { 
            get { return  _picture_url; } 
            set { _picture_url = value; } 
        }
        /// <summary>
        /// Category of the item
        /// </summary>
        public string CategoryId { 
            get { return  _category_id; } 
            set { _category_id = value; } 
        }
        /// <summary>
        /// Item's quantity
        /// </summary>
        public int? Quantity {
            get { return  _quantity; } 
            set { _quantity = value; } 
        }
        /// <summary>
        /// Unit price
        /// </summary>
        public decimal? UnitPrice { 
            get { return  _unit_price; } 
            set { _unit_price = value; } 
        }
        /// <summary>
        /// Passenger
        /// </summary>
        public Passenger? Passenger { 
            get { return _passenger; }
            set { _passenger = value; }
        }
        /// <summary>
        /// Route
        /// </summary>
        public Route? Route { 
            get { return _route; }
            set { _route = value; }
        }
        /// <summary>
        /// Warranty
        /// </summary>
        public bool Warranty { 
            get { return _warranty; }
            set { _warranty = value; }
        }
        /// <summary>
        /// Event Date
        /// </summary>
        public DateTime? EventDate
        {
            get { return _event_date; }
            set { _event_date = value; }
        }
        #endregion
    }
}
