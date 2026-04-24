namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Represents an external classification category for an <see cref="OrderItems"/> entry,
    /// used to map items to third-party or platform-specific category systems.
    /// </summary>
    public class OrderExternalCategory
    {
        /// <summary>
        /// External category identifier from the third-party or platform classification system.
        /// </summary>
        public string Id { get; set; }
    }
}
