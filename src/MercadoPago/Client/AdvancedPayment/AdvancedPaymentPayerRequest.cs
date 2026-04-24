namespace MercadoPago.Client.AdvancedPayment
{
    using MercadoPago.Client.Common;

    /// <summary>
    /// Information about the buyer making the advanced payment.
    /// This is a required field in <see cref="AdvancedPaymentCreateRequest"/>.
    /// </summary>
    public class AdvancedPaymentPayerRequest
    {
        /// <summary>
        /// Payer type identifier. Mandatory when the payer is a registered MercadoPago customer
        /// (e.g., <c>"customer"</c>).
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Unique identifier of the payer in MercadoPago. Required when <see cref="Type"/> is set.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Payer's email address. Used for notifications and fraud analysis.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Payer's personal identification document (e.g., CPF, DNI, CURP).
        /// </summary>
        public IdentificationRequest Identification { get; set; }

        /// <summary>
        /// Payer's first name as it appears on their identification document.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Payer's last name as it appears on their identification document.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Entity type of the payer. Applicable only for bank transfer payments
        /// (e.g., <c>"individual"</c> or <c>"association"</c>).
        /// </summary>
        public string EntityType { get; set; }

        /// <summary>
        /// Payer's billing or residential address.
        /// </summary>
        public AddressRequest Address { get; set; }
    }
}
