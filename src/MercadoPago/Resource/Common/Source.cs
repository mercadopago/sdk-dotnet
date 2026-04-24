namespace MercadoPago.Resource.Common
{
    /// <summary>
    /// Identifies the origin of an action or event in the MercadoPago
    /// platform (e.g. the source of a refund or a chargeback). Appears in
    /// API responses that track who or what initiated an operation.
    /// </summary>
    public class Source
    {
        /// <summary>
        /// Unique identifier of the source entity.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Human-readable name of the source entity.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Type of the source entity (e.g. <c>collector</c>, <c>operator</c>,
        /// <c>admin</c>).
        /// </summary>
        public string Type { get; set; }
    }
}
