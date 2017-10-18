using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Preference
{    
    public struct Item
    {
        #region Properties

        [StringLength(256)]
        private string id;
        [StringLength(256)]
        private string title;
        [StringLength(256)]
        private string description;
        [StringLength(600)]
        private string pictureUrl;
        [StringLength(256)]
        private int categoryId;
        private int quantity;
        [StringLength(3)]
        private string currencyId;
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99)]
        private float unitPrice;

        #endregion

        #region Accessors
       
        public string ID 
        {
            get { return this.id; }
            set { this.id = value; }
        }        

        public string Title
        { 
            get { return this.title; } 
            set{this.title = value;}
        }        

        public string Description 
        {
            get { return this.description; }
            set { this.description = value; }
        }

        public string PictureUrl 
        {
            get { return this.pictureUrl; }
            set { this.pictureUrl = value; } 
        }        

        public int CategoryId 
        {
            get { return this.categoryId; }
            set { this.categoryId = value; } 
        }        

        public int Quantity 
        {
            get { return this.quantity; }
            set { this.quantity = value; }
        }        

        public string CurrencyId 
        {
            get { return this.currencyId; }
            set { this.currencyId = value; } 
        }        

        public float UnitPrice 
        {
            get { return this.unitPrice; }
            set { this.unitPrice = value; }
        }

        #endregion
    }
}
