using MercadoPago.Client.Common;

namespace MercadoPago.Client.Payment
{
    /// <summary>
    /// Payer information attached to a <see cref="PaymentCreateRequest"/>.
    /// Identifies the person or entity making the payment, including personal data,
    /// contact information, and address.
    /// </summary>
    public class PaymentPayerRequest
    {
        /// <summary>
        /// Payer type. Mandatory when the payer is a registered MercadoPago customer.
        /// Possible values: "customer", "registered", "guest".
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Payer's unique identifier in MercadoPago.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Email address of the payer. Required for most payment methods.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Payer's personal identification document (e.g., CPF, DNI).
        /// Required for card payments in most countries.
        /// </summary>
        /// <seealso cref="IdentificationRequest"/>
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
        /// Payer's entity type, applicable only for bank transfer payments.
        /// Possible values: "individual", "association".
        /// </summary>
        public string EntityType { get; set; }

        /// <summary>
        /// Payer's address details, including street, neighborhood, city, and federal unit.
        /// </summary>
        /// <seealso cref="PaymentPayerAddressRequest"/>
        public PaymentPayerAddressRequest Address { get; set; }

        /// <summary>
        /// Payer's phone number details, including area code and number.
        /// </summary>
        /// <seealso cref="PaymentPayerPhoneRequest"/>
        public PaymentPayerPhoneRequest Phone { get; set; }
    }
}
