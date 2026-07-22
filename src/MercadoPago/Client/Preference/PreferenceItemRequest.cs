namespace MercadoPago.Client.Preference
{
    using System;

    /// <summary>
    /// Represents an item the buyer will pay for in a Checkout Pro preference.
    /// At least one item is required to create a <see cref="PreferenceRequest"/>.
    /// </summary>
    public class PreferenceItemRequest
    {
        /// <summary>
        /// Item code in your catalog. Used to identify the item in your system.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Item name displayed to the buyer at checkout.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Detailed item description shown to the buyer.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// URL of the item image displayed at checkout.
        /// </summary>
        public string PictureUrl { get; set; }

        /// <summary>
        /// Category identifier for the item, used for fraud prevention analysis.
        /// </summary>
        public string CategoryId { get; set; }

        /// <summary>
        /// Item type identifier used for industry-specific processing rules
        /// (e.g., <c>"product"</c>, <c>"service"</c>, <c>"travel"</c>).
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Number of units of this item. Must be an integer greater than zero.
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// Unit price of the item. The total for this line is <see cref="UnitPrice"/> multiplied by <see cref="Quantity"/>.
        /// </summary>
        public decimal? UnitPrice { get; set; }

        /// <summary>
        /// Currency identifier in ISO 4217 format (e.g., <c>"ARS"</c>, <c>"BRL"</c>, <c>"USD"</c>).
        /// </summary>
        public string CurrencyId { get; set; }

        /// <summary>
        /// Category-specific descriptor with additional item metadata, such as passenger or route
        /// information for travel-related items.
        /// </summary>
        /// <seealso cref="PreferenceCategoryDescriptorRequest"/>
        public PreferenceCategoryDescriptorRequest CategoryDescriptor { get; set; }

        /// <summary>
        /// <c>true</c> if the item includes a warranty, <c>false</c> otherwise.
        /// </summary>
        public bool? Warranty { get; set; }

        /// <summary>
        /// Date of the event associated with this item (e.g., a concert or trip date).
        /// </summary>
        public DateTime? EventDate { get; set; }
    }
}
