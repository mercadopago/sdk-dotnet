namespace MercadoPago.Resource.Payment
{
    using MercadoPago.Resource.Common;

    /// <summary>
    /// Information about the payer (buyer) who made a <see cref="Payment"/>,
    /// including personal identification, email, and entity type.
    /// </summary>
    public class PaymentPayer
    {
        /// <summary>
        /// Payer type. Possible values: "customer" (registered MercadoPago user),
        /// "registered" (registered user without stored cards), or "guest"
        /// (unregistered user). Mandatory if the payer is a Customer.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Unique identifier of the payer in MercadoPago.
        /// For registered customers, this is their MercadoPago user ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Email address of the payer. Used for notifications and receipts.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Payer's identification document (e.g., CPF, DNI, CURP),
        /// including type and number.
        /// </summary>
        public Identification Identification { get; set; }

        /// <summary>
        /// Payer's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Payer's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Entity type of the payer. Only applicable for bank transfer payments.
        /// Possible values: "individual" or "association".
        /// </summary>
        public string EntityType { get; set; }

    }
}
