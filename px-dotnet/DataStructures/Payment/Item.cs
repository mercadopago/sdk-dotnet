using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Payment
{
    public struct Item
    {
        /// <summary>
        /// Item code
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Item name
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Long item description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Image URL
        /// </summary>
        public string PictureUrl { get; set; }

        /// <summary>
        /// Category of the item
        /// </summary>
        public string CategoryId { get; set; }

        /// <summary>
        /// Item's quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Unit price
        /// </summary>
        public int UnitPrice { get; set; }
    }
}
