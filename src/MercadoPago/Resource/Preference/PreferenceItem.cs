namespace MercadoPago.Resource.Preference
{
    using System;

    /// <summary>
    /// Represents a product or service item within a <see cref="Preference"/>.
    /// Each item defines what the buyer will purchase, including its price, quantity,
    /// and optional category-specific metadata.
    /// </summary>
    public class PreferenceItem
    {
        /// <summary>
        /// Item code or SKU that uniquely identifies the product in the merchant's catalog.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Display name of the item shown to the buyer during checkout.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Detailed description of the item, providing additional product information beyond the title.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// URL of the item's image, displayed in the Checkout Pro flow.
        /// </summary>
        public string PictureUrl { get; set; }

        /// <summary>
        /// Category identifier of the item. Helps MercadoPago with fraud prevention
        /// and industry-specific processing rules.
        /// </summary>
        public string CategoryId { get; set; }

        /// <summary>
        /// Item type identifier used for industry-specific processing rules
        /// (e.g., <c>"product"</c>, <c>"service"</c>, <c>"travel"</c>).
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Number of units of this item being purchased.
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// Price per unit of the item, in the currency specified by <see cref="CurrencyId"/>.
        /// </summary>
        public decimal? UnitPrice { get; set; }

        /// <summary>
        /// ISO 4217 currency code for the item price (e.g., <c>ARS</c>, <c>BRL</c>, <c>MXN</c>).
        /// </summary>
        public string CurrencyId { get; set; }

        /// <summary>
        /// Category-specific metadata for this item, typically used for travel-related products
        /// such as airline tickets (passenger and route information).
        /// </summary>
        public PreferenceCategoryDescriptor CategoryDescriptor { get; set; }

        /// <summary>
        /// Indicates whether the item includes a warranty.
        /// <c>true</c> if the item is purchased with warranty, <c>false</c> otherwise.
        /// </summary>
        public bool? Warranty { get; set; }

        /// <summary>
        /// Date of the event associated with this item (e.g., concert date, travel date).
        /// </summary>
        public DateTime? EventDate { get; set; }
    }
}
