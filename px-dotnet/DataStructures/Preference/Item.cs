using System;
using MercadoPago.Common;

namespace MercadoPago.DataStructures.Preference
{
    /// <summary>
    /// Purchased item
    /// </summary>
    public struct Item
    {
        /// <summary>
        /// Item ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Item title. It will be displayed in the payment process.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Item description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Item image URL
        /// </summary>
        public string PictureUrl { get; set; }

        /// <summary>
        /// Item category ID
        /// </summary>
        public string CategoryId { get; set; }

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
        public decimal UnitPrice { get; set; }

        /// <sumary>
        /// Passenger. Info adicional en caso de category_id travels
        /// </sumary>
        public Passenger Passenger { get; set; }

        /// <sumary>
        /// Route. Info adicional en caso de category_id travels
        /// </sumary>
        public Route Route { get; set; }

        /// <sumary>
        /// Warranty
        /// </sumary>
        public Boolean? Warranty { get; set; }

        /// <sumary>
        /// Event date
        /// </sumary>
        public DateTime? Event_date { get; set; }

    }
}