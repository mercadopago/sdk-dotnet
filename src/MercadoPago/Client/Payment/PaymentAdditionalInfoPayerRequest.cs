namespace MercadoPago.Client.Payment
{
    using System;
    using MercadoPago.Client.Common;

    /// <summary>
    /// Extended payer information included in <see cref="PaymentAdditionalInfoRequest"/>
    /// to enhance fraud analysis. Contains details about the payer's account history
    /// and purchase behavior on the merchant's platform.
    /// </summary>
    public class PaymentAdditionalInfoPayerRequest
    {
        /// <summary>
        /// Payer's first name as registered on the merchant's site.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Payer's last name as registered on the merchant's site.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Payer's phone contact information.
        /// </summary>
        /// <seealso cref="PhoneRequest"/>
        public PhoneRequest Phone { get; set; }

        /// <summary>
        /// Payer's address as registered on the merchant's site.
        /// </summary>
        /// <seealso cref="AddressRequest"/>
        public AddressRequest Address { get; set; }

        /// <summary>
        /// Date when the payer registered on the merchant's site.
        /// Used for fraud risk assessment.
        /// </summary>
        public DateTime? RegistrationDate { get; set; }

        /// <summary>
        /// Authentication method used by the payer on the merchant's site
        /// (e.g., "Gmail", "Facebook", "Native").
        /// </summary>
        public string AuthenticationType { get; set; }

        /// <summary>
        /// <c>true</c> if the payer is a premium or prime user on the merchant's platform;
        /// otherwise, <c>false</c>.
        /// </summary>
        public bool? IsPrimeUser { get; set; }

        /// <summary>
        /// <c>true</c> if this is the payer's first online purchase on the merchant's platform;
        /// otherwise, <c>false</c>.
        /// </summary>
        public bool? IsFirstPurchaseOnline { get; set; }

        /// <summary>
        /// Date and time of the payer's last purchase on the merchant's platform.
        /// </summary>
        public DateTime? LastPurchase { get; set; }

        /// <summary>
        /// Payer's personal identification document data (type and number).
        /// </summary>
        /// <seealso cref="IdentificationRequest"/>
        public IdentificationRequest Identification { get; set; }
    }
}
