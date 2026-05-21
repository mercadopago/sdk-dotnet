namespace MercadoPago.Resource.Common
{
    /// <summary>
    /// Personal identification document data used across several MercadoPago
    /// API responses (customers, payments, card holders, etc.). The
    /// <see cref="Type"/> value corresponds to one of the types returned by
    /// <see cref="IdentificationType.IdentificationType"/>.
    /// </summary>
    public class Identification
    {
        /// <summary>
        /// Identification document type (e.g. <c>CPF</c>, <c>DNI</c>,
        /// <c>CNPJ</c>). Valid values depend on the country and can be
        /// retrieved via the Identification Types API.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Identification document number.
        /// </summary>
        public string Number { get; set; }
    }
}
