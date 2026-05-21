// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Represents a payer's identity document used for order verification and compliance.
    /// </summary>
    /// <seealso cref="OrderPayerRequest"/>
    public class OrderIdentificationRequest
    {
        /// <summary>
        /// Type of identification document (e.g., "CPF", "CNPJ", "DNI", "CURP").
        /// Accepted values depend on the payer's country.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Unique number of the identification document.
        /// </summary>
        public string Number { get; set; }
    }

}
