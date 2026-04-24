// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Represents the payer (buyer) associated with a payment order, including personal
    /// information, identification documents, contact details, and billing address.
    /// </summary>
    /// <seealso cref="OrderCreateRequest"/>
    public class OrderPayerRequest
    {
        /// <summary>
        /// Payer's email address, used for notifications and identification.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Entity type of the payer (e.g., "individual" or "association").
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
        /// MercadoPago customer ID, used to link the payer to a stored customer profile.
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Payer's identity document information (type and number).
        /// </summary>
        /// <seealso cref="OrderIdentificationRequest"/>
        public OrderIdentificationRequest Identification { get; set; }

        /// <summary>
        /// Payer's phone contact information.
        /// </summary>
        /// <seealso cref="OrderPhoneRequest"/>
        public OrderPhoneRequest Phone { get; set; }

        /// <summary>
        /// Payer's billing address.
        /// </summary>
        /// <seealso cref="OrderAddressRequest"/>
        public OrderAddressRequest Address { get; set; }
    }
}
