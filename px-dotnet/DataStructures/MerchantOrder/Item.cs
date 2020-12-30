using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.MerchantOrder
{
    /// <summary>
    /// Item information.
    /// </summary>
    public struct Item
    {
        #region Properties

        private string id;
        private string categoryId;
        [RegularExpression(@"^.{3,3}$")]        
        private string currencyId;
        private string description;
        private string pictureUrl;
        private int quantity;
        private float unitPrice;
        private string title;

        #endregion

        #region Accessors

        /// <summary>
        /// Item ID.
        /// </summary>
        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Category ID.
        /// </summary>
        public string CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }

        /// <summary>
        /// Currency ID.
        /// </summary>
        public string CurrencyId
        {
            get { return currencyId; }
            set { currencyId = value; }
        }
       
        /// <summary>
        /// Description.
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }        

        /// <summary>
        /// Picture URL.
        /// </summary>
        public string PictureUrl
        {
            get { return pictureUrl; }
            set { pictureUrl = value; }
        }

        /// <summary>
        /// Quantity.
        /// </summary>
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        /// <summary>
        /// Unit Price.
        /// </summary>
        public float UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }

        /// <summary>
        /// Title.
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        #endregion
    }
}
