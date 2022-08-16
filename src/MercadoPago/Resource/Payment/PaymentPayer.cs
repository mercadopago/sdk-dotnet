namespace MercadoPago.Resource.Payment
{
    using MercadoPago.Resource.Common;

    /// <summary>
    /// Payer information.
    /// </summary>
    public class PaymentPayer
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
        /// Payer's entity type (only for bank transfers).
        /// </summary>
        public string EntityType { get; set; }

    }
}
