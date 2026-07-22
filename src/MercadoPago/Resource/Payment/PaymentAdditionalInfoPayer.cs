namespace MercadoPago.Resource.Payment
{
    using System;
    using MercadoPago.Resource.Common;

    /// <summary>
    /// Extended payer information supplied within <see cref="PaymentAdditionalInfo"/>
    /// to improve fraud analysis and conversion rates.
    /// </summary>
    public class PaymentAdditionalInfoPayer
    {
        /// <summary>
        /// Payer's first name as known by the merchant.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Payer's last name as known by the merchant.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Payer's phone information, including area code and number.
        /// </summary>
        public Phone Phone { get; set; }

        /// <summary>
        /// Payer's address information, including street, zip code, and city.
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Date when the payer registered on the merchant's site. Useful for
        /// fraud analysis to assess account age.
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
        public Identification Identification { get; set; }
    }
}
