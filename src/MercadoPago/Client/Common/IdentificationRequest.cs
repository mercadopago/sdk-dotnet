namespace MercadoPago.Client.Common
{
    /// <summary>
    /// Reusable personal identification DTO used to represent a government-issued
    /// document in payment payer data, customer profiles, and card-token requests.
    /// Valid identification types can be retrieved via
    /// <see cref="IdentificationType.IdentificationTypeClient"/>.
    /// </summary>
    public class IdentificationRequest
    {
        /// <summary>
        /// Identification document type code (e.g., <c>"CPF"</c>, <c>"CNPJ"</c>, <c>"DNI"</c>).
        /// Use <see cref="IdentificationType.IdentificationTypeClient.ListAsync"/> to retrieve
        /// the valid types for the current country.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Identification document number (e.g., <c>"12345678909"</c> for a Brazilian CPF).
        /// </summary>
        public string Number { get; set; }
    }
}
