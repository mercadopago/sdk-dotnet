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
        /// <summary>
        /// Item ID
        /// </summary>
        [StringLength(256)]
        public string Id { get; set; }

        /// <summary>
        /// Item title. It will be displayed in the payment process.
        /// </summary>
        [StringLength(256)]
        public string Title { get; set; }

        /// <summary>
        /// Item description
        /// </summary>
        [StringLength(256)]
        public string Description { get; set; }

        /// <summary>
        /// Item image URL
        /// </summary>
        [StringLength(600)]
        public string PictureUrl { get; set; }

        /// <summary>
        /// Item category ID
        /// </summary>
        [StringLength(256)]
        // TODO: [StringLength] on an int? Property???
        public int? CategoryId { get; set; }

        /// <summary>
        /// Item quantity
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// Currency ID. ISO_4217 code
        /// </summary>
        public CurrencyId CurrencyId { get; set; }

        /// <summary>
        /// Unit price
        /// </summary>
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        // TODO: Regexp in a decimal Property???
        [Range(0, 9999999999999999.99)]
        public decimal UnitPrice { get; set; }
    }
}
