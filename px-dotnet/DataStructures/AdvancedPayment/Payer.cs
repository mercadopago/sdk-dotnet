namespace MercadoPago.DataStructures.AdvancedPayment
{
    /// <summary>
    /// Payer data
    /// </summary>
    public class Payer
    {
        /// <summary>
        /// Payer identification
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Payer type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Identification
        /// </summary>
        public Identification Identification { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        public Phone Phone { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; }
    }
}
