using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Payment
{
    public struct Item
    {
        #region Properties

        private string id;
        private string title;
        private string description;
        private string pictureUrl;
        private string categoryId;
        private int quantity;
        private int unitPrice;

        #endregion

        #region Accessors

        public string ID
        {
            get { return id; }
            set { id = value; }
        }
       
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        
        public string PictureUrl
        {
            get { return pictureUrl; }
            set { pictureUrl = value; }
        }
        
        public string CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }
        
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
       
        public int UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }

        #endregion
    }
}
