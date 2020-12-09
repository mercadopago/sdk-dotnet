using System;
using MercadoPago.Resource.Common;

namespace MercadoPago.Resource.Preference
{
    /// <summary>
    /// Payer information from <see cref="Preference"/>.
    /// </summary>
    public class PreferencePayer
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
        public Phone Phone { get; set; }

        /// <summary>
        /// Payer's identification.
        /// </summary>
        public Identification Identification { get; set; }

        /// <summary>
        /// Payer's address.
        /// </summary>
        public Address Address { get; set; }

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
    }
}
