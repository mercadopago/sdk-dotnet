using System;
using MercadoPago.Resource.Common;

namespace MercadoPago.Resource.Preference
{
    /// <summary>
    /// Represents the payer (buyer) information within a <see cref="Preference"/>.
    /// Used to pre-fill buyer data in the checkout flow and to improve fraud analysis
    /// with historical purchase behavior.
    /// </summary>
    public class PreferencePayer
    {
        /// <summary>
        /// Payer's first name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Payer's last name (family name).
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Payer's email address, used for notifications and account matching.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Payer's phone number details.
        /// </summary>
        public Phone Phone { get; set; }

        /// <summary>
        /// Payer's personal identification document (e.g., CPF, DNI, CURP).
        /// </summary>
        public Identification Identification { get; set; }

        /// <summary>
        /// Payer's residential or billing address.
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Date and time when the payer's account was created on the merchant's platform.
        /// Helps assess account age for fraud analysis.
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Authentication method used by the payer on the merchant's site
        /// (e.g., <c>Gmail</c>, <c>Facebook</c>, <c>native</c>).
        /// </summary>
        public string AuthenticationType { get; set; }

        /// <summary>
        /// Indicates whether the payer is a MercadoLibre Loyalty (formerly "Prime") member.
        /// <c>true</c> if the user has a loyalty subscription, <c>false</c> otherwise.
        /// </summary>
        public bool? IsPrimeUser { get; set; }

        /// <summary>
        /// Indicates whether this is the payer's first online purchase on the merchant's platform.
        /// <c>true</c> if it is their first purchase, <c>false</c> otherwise.
        /// </summary>
        public bool? IsFirstPurchaseOnline { get; set; }

        /// <summary>
        /// Date and time of the payer's most recent purchase on the merchant's platform.
        /// </summary>
        public DateTime? LastPurchase { get; set; }
    }
}
