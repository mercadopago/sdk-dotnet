using System.Collections.Generic;

// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Represents a product or service line item within an <see cref="Order"/>, including pricing,
    /// quantity, and categorization details.
    /// </summary>
    public class OrderItems
    {
        /// <summary>
        /// Display name of the item shown to the payer during checkout.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Price per unit of this item, expressed in the order currency.
        /// </summary>
        public string UnitPrice { get; set; }

        /// <summary>
        /// Detailed description of the item, providing additional information beyond the title.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// MercadoPago category identifier for this item, used for risk analysis and reporting.
        /// </summary>
        public string CategoryId { get; set; }

        /// <summary>
        /// Item type classification (e.g., "physical", "digital", "service") that may affect shipping and tax rules.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// URL of the item image displayed to the payer during the checkout flow.
        /// </summary>
        public string PictureUrl { get; set; }

        /// <summary>
        /// Number of units of this item included in the order.
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// Indicates whether this item includes a warranty.
        /// </summary>
        public bool? Warranty { get; set; }

        /// <summary>
        /// ISO 8601 date associated with the item, typically used for event tickets or scheduled services.
        /// </summary>
        public string EventDate { get; set; }

        /// <summary>
        /// Unit of measurement for the item quantity (e.g., "unit", "kg", "meter").
        /// </summary>
        public string UnitMeasure { get; set; }

        /// <summary>
        /// List of <see cref="OrderExternalCategory"/> entries representing external classification codes for this item.
        /// </summary>
        public IList<OrderExternalCategory> ExternalCategories { get; set; }
    }
}
