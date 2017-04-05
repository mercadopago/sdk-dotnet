using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources.DataStructures.Preference
{
    public class Item
    {
        #region Properties

        [StringLength(256)]
        private string id = null;
        [StringLength(256)]
        private string title = null;
        [StringLength(256)]
        private string description = null;
        [StringLength(600)]
        private string pictureUrl = null;
        [StringLength(256)]
        private int? categoryId = null;
        private int? quantity = null;
        [StringLength(3)]
        private string currencyId = null;
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99)]
        private decimal? unitPrice = null;

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
            get { return this.categoryId.Value; }
            set { this.categoryId = value; } 
        }        

        public int Quantity 
        {
            get { return this.quantity.Value; }
            set { this.quantity = value; }
        }        

        public string CurrencyId 
        {
            get { return this.currencyId; }
            set { this.currencyId = value; } 
        }        

        public decimal UnitPrice 
        {
            get { return this.unitPrice.Value; }
            set { this.unitPrice = value; }
        }

        #endregion
    }
}
