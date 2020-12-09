namespace MercadoPago.Client.AdvancedPayment
{
    using MercadoPago.Client.Common;

    /// <summary>
    /// Payer information.
    /// </summary>
    public class AdvancedPaymentPayerRequest
    {
        /// <summary>
        /// Payer's identification type (mandatory if the payer is a Customer).
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Payer's ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Email of the payer.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Payer's personal identification.
        /// </summary>
        public IdentificationRequest Identification { get; set; }

        /// <summary>
        /// Payer's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Payer's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Payer's entity type (only for bank transfers).
        /// </summary>
        public string EntityType { get; set; }

        /// <summary>
        /// Payer's address.
        /// </summary>
        public AddressRequest Address { get; set; }
    }
}
