namespace MercadoPago.Resource.AdvancedPayment
{
    using MercadoPago.Resource.Common;

    /// <summary>
    /// Represents the payer who is making the <see cref="AdvancedPayment"/>.
    /// Contains identification, contact details, and address information.
    /// </summary>
    public class AdvancedPaymentPayer
    {
        /// <summary>
        /// Payer type. Mandatory if the payer is a registered Customer.
        /// Common values: <c>customer</c>, <c>guest</c>.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Unique identifier of the payer in the MercadoPago platform.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Email address of the payer, used for notifications and identification.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Payer's personal identification document (e.g., CPF, DNI, CURP).
        /// </summary>
        public Identification Identification { get; set; }

        /// <summary>
        /// Payer's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Payer's last name (family name).
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Payer's entity type. Required only for bank transfer payments.
        /// Common values: <c>individual</c>, <c>association</c>.
        /// </summary>
        public string EntityType { get; set; }

        /// <summary>
        /// Payer's residential or billing address.
        /// </summary>
        public Address Address { get; set; }
    }
}
