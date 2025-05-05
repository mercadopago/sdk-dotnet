namespace MercadoPago.Client.Preference
{
    using System;
    using MercadoPago.Client.Common;

    /// <summary>
    /// Payer information.
    /// </summary>
    public class PreferencePayerRequest
    {
        /// <summary>
        /// Payer's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Payer's surname.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Payer's email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Payer's phone.
        /// </summary>
        public PhoneRequest Phone { get; set; }

        /// <summary>
        /// Payer's identification.
        /// </summary>
        public IdentificationRequest Identification { get; set; }

        /// <summary>
        /// Payer's address.
        /// </summary>
        public AddressRequest Address { get; set; }

        /// <summary>
        /// Date of creation of the payer user.
        /// </summary>
        public DateTime? DateCreated { get; set; }

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

        /// <summary>
        /// Date of registration.
        /// </summary>
        public DateTime? RegistrationDate { get; set; }
    }
}
