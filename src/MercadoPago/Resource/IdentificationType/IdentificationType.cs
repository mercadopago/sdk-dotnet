namespace MercadoPago.Resource.IdentificationType
{
    using MercadoPago.Http;

    /// <summary>
    /// Represents an identification document type supported by MercadoPago for
    /// a given country (e.g. <c>CPF</c> in Brazil, <c>DNI</c> in Argentina).
    /// Returned as a list by the Identification Types API. Use
    /// <see cref="Client.IdentificationType.IdentificationTypeClient"/> to
    /// retrieve the available types for the caller's country.
    /// </summary>
    /// <remarks>
    /// For more information, access
    /// <a href="https://www.mercadopago.com/developers/en/reference/identification_types/resource/">here</a>.
    /// </remarks>
    public class IdentificationType : IResource
    {
        /// <summary>
        /// Short identifier code for this document type (e.g. <c>CPF</c>,
        /// <c>DNI</c>, <c>CNPJ</c>).
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Human-readable name of the identification type.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Data type of the identification number (e.g. <c>number</c>,
        /// <c>string</c>).
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Minimum allowed length for identification numbers of this type.
        /// </summary>
        public int? MinLength { get; set; }

        /// <summary>
        /// Maximum allowed length for identification numbers of this type.
        /// </summary>
        public int? MaxLength { get; set; }

        /// <summary>
        /// Raw HTTP response returned by the MercadoPago API for the request
        /// that produced this resource.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
