namespace MercadoPago.Resource.IdentificationType
{
    using MercadoPago.Http;

    /// <summary>
    /// Identification Type resource.
    /// </summary>
    /// <remarks>
    /// For more information, access
    /// <a href="https://www.mercadopago.com/developers/en/reference/identification_types/resource/">here</a>.
    /// </remarks>
    public class IdentificationType : IResource
    {
        /// <summary>
        /// Identification type ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Identification type name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Identification number data type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Identification type min length.
        /// </summary>
        public int? MinLength { get; set; }

        /// <summary>
        /// Identification type max length.
        /// </summary>
        public int? MaxLength { get; set; }

        /// <summary>
        /// Response from API.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
