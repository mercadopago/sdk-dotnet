// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Represents a single line item (product or service) included in a payment order.
    /// Multiple items can be attached to an <see cref="OrderCreateRequest"/>.
    /// </summary>
    /// <seealso cref="OrderCreateRequest"/>
    public class OrderItemsRequest
    {
        /// <summary>
        /// Display title of the item shown to the payer (e.g., "Blue T-Shirt").
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Unit price of the item expressed as a decimal string (e.g., "49.90").
        /// </summary>
        public string UnitPrice { get; set; }

        /// <summary>
        /// Number of units of this item included in the order.
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// External code used to identify the item in your own inventory or catalog system.
        /// </summary>
        public string ExternalCode { get; set; }

        /// <summary>
        /// Category identifier for the item, used for risk analysis and reporting.
        /// </summary>
        public string CategoryId { get; set; }

        /// <summary>
        /// Type classifier for the item (e.g., "physical", "digital", "service").
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Detailed description of the item.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// URL pointing to a representative image of the item.
        /// </summary>
        public string PictureUrl { get; set; }

        /// <summary>
        /// Indicates whether the item includes a warranty.
        /// </summary>
        public bool? Warranty { get; set; }

        /// <summary>
        /// Date of the event associated with the item, if applicable (e.g., a concert date), in ISO 8601 format.
        /// </summary>
        public string EventDate { get; set; }
    }
}
