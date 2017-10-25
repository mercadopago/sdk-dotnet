using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using MercadoPago.Common;

namespace MercadoPago.DataStructures.Preference
{    
    public struct Item
    {
        #region Properties 
        [StringLength(256)]
        private string _id;
        [StringLength(256)]
        private string _title;
        [StringLength(256)]
        private string _description;
        [StringLength(600)]
        private string _pictureU_url;
        [StringLength(256)]
        private int? _category_id;
        private int? _quantity;
        [StringLength(3)]
        private CurrencyId _currency_id;
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99)]
        private float unit_price; 
        #endregion

        #region Accessors 
        /// <summary>
        /// Item ID
        /// </summary>
        public string Id
        { 
            get => _id; 
            set => _id = value;
        }
        /// <summary>
        /// Item title. It will be displayed in the payment process.
        /// </summary>
        public string Title
        {
            get => _title; 
            set => _title = value;
        }
        /// <summary>
        /// Item description
        /// </summary>
        public string Description
        {
            get => _description; 
            set => _description = value; 
        }
        /// <summary>
        /// Item image URL
        /// </summary>
        public string PictureUrl
        {
            get => _pictureU_url;
            set => _pictureU_url = value;
        }
        /// <summary>
        /// Item category ID
        /// </summary>
        public int? CategoryId
        {
            get => _category_id;
            set => _category_id = value;
        }
        /// <summary>
        /// Item quantity
        /// </summary>
        public int? Quantity
        {
            get => _quantity;
            set => _quantity = value;
        }
        /// <summary>
        /// Currency ID. ISO_4217 code
        /// </summary>
        public CurrencyId CurrencyId
        {
            get => _currency_id; 
            set => _currency_id = value;
        }
        /// <summary>
        /// Unit price
        /// </summary>
        public float UnitPrice
        {
            get => unit_price; 
            set => unit_price = value;
        } 
        #endregion
    }
}
