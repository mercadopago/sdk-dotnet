namespace MercadoPago.Client.Preference
{
    using System;
    using MercadoPago.Client.Common;

    /// <summary>
    /// Buyer information for a Checkout Pro preference. Providing payer data helps pre-fill
    /// checkout fields and improves fraud prevention analysis.
    /// </summary>
    /// <seealso cref="PreferenceRequest"/>
    public class PreferencePayerRequest
    {
        /// <summary>
        /// Buyer's first name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Buyer's last name.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Buyer's email address. Used for payment notifications and checkout identification.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Buyer's phone number, including area code.
        /// </summary>
        /// <seealso cref="PhoneRequest"/>
        public PhoneRequest Phone { get; set; }

        /// <summary>
        /// Buyer's identification document (e.g., CPF, DNI, CUIT).
        /// </summary>
        /// <seealso cref="IdentificationRequest"/>
        public IdentificationRequest Identification { get; set; }

        /// <summary>
        /// Buyer's residential address.
        /// </summary>
        /// <seealso cref="AddressRequest"/>
        public AddressRequest Address { get; set; }

        /// <summary>
        /// Date when the buyer's account was created in your platform.
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Authentication type the buyer used on your site (e.g., <c>"gmail"</c>, <c>"facebook"</c>, <c>"native"</c>).
        /// </summary>
        public string AuthenticationType { get; set; }

        /// <summary>
        /// <c>true</c> if the buyer is a Prime or premium user on your platform, <c>false</c> otherwise.
        /// </summary>
        public bool? IsPrimeUser { get; set; }

        /// <summary>
        /// <c>true</c> if this is the buyer's first online purchase, <c>false</c> otherwise.
        /// </summary>
        public bool? IsFirstPurchaseOnline { get; set; }

        /// <summary>
        /// Date of the buyer's most recent purchase on your platform.
        /// </summary>
        public DateTime? LastPurchase { get; set; }

        /// <summary>
        /// Date when the buyer registered on your platform.
        /// </summary>
        public DateTime? RegistrationDate { get; set; }
    }
}
