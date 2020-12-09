namespace MercadoPago.Resource.AdvancedPayment
{
    using System;
    using MercadoPago.Resource.Common;

    /// <summary>
    /// Additional info payer information.
    /// </summary>
    public class AdvancedPaymentAdditionalInfoPayer
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
        public Phone Phone { get; set; }

        /// <summary>
        /// Payer's address.
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Date of registration of the payer on your site.
        /// </summary>
        public DateTime? RegistrationDate { get; set; }
    }
}
