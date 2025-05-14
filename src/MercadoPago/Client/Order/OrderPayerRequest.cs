// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Payer class.
    /// </summary>
    public class OrderPayerRequest
    {
        /// <summary>
        /// Payer's email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Payer's entity type.
        /// </summary>
        public string EntityType { get; set; }

        /// <summary>
        /// Payer's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Payer's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Customer ID.
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Identification information.
        /// </summary>
        public OrderIdentificationRequest Identification { get; set; }

        /// <summary>
        /// Phone information.
        /// </summary>
        public OrderPhoneRequest Phone { get; set; }

        /// <summary>
        /// Address information.
        /// </summary>
        public OrderAddressRequest Address { get; set; }
    }
}
