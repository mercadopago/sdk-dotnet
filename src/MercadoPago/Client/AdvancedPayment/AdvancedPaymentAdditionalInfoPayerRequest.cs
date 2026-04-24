namespace MercadoPago.Client.AdvancedPayment
{
    using System;
    using MercadoPago.Client.Common;

    /// <summary>
    /// Payer details included in the additional information section of an advanced payment request.
    /// Providing accurate payer data improves fraud analysis and conversion rates.
    /// </summary>
    /// <see cref="AdvancedPaymentAdditionalInfoRequest"/>
    public class AdvancedPaymentAdditionalInfoPayerRequest
    {
        /// <summary>
        /// Payer's first name as it appears on their identification document.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Payer's last name as it appears on their identification document.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Payer's phone information, including area code and number.
        /// </summary>
        public PhoneRequest Phone { get; set; }

        /// <summary>
        /// Payer's residential or billing address.
        /// </summary>
        public AddressRequest Address { get; set; }

        /// <summary>
        /// Date when the payer registered on your platform.
        /// Used by the fraud prevention engine to assess account maturity.
        /// </summary>
        public DateTime? RegistrationDate { get; set; }
    }
}
