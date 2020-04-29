using System;

namespace MercadoPago.DataStructures.AdvancedPayment
{
    /// <summary>
    /// Payer additional info
    /// </summary>
    public class AdditionalInfoPayer
    {
        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        public Phone Phone { get; set; }

        /// <summary>
        /// Payer registration date on your site
        /// </summary>
        public DateTime RegistrationDate { get; set; }
    }
}
