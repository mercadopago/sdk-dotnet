namespace MercadoPago.Client.Payment
{
    using System;
    using MercadoPago.Client.Common;

    /// <summary>
    /// Additional info payer information.
    /// </summary>
    public class PaymentAdditionalInfoPayerRequest
    {
        /// <summary>
        /// Payer's name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Payer's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Payer's phone.
        /// </summary>
        public PhoneRequest Phone { get; set; }

        /// <summary>
        /// Payer's address.
        /// </summary>
        public AddressRequest Address { get; set; }

        /// <summary>
        /// Date of registration of the payer on your site.
        /// </summary>
        public DateTime? RegistrationDate { get; set; }

        /// <summary>
        /// The authentication type of payer in your site.
        /// </summary>
        public string AuthenticationType { get; set; }

        /// <summary>
        /// <c>true</c> if the user is Prime, <c>false</c> if not.
        /// </summary>
        public bool? IsPrimeUser { get; set; }

        /// <summary>
        /// If is the first purchase online <c>true</c>, <c>true</c> if not.
        /// </summary>
        public bool? IsFirstPurchaseOnline { get; set; }

        /// <summary>
        /// Date of the last purchase.
        /// </summary>
        public DateTime? LastPurchase { get; set; }
    }
}
