namespace MercadoPago.Resource.AdvancedPayment
{
    using System;
    using MercadoPago.Resource.Common;

    /// <summary>
    /// Represents additional payer information within <see cref="AdvancedPaymentAdditionalInfo"/>,
    /// used to enrich fraud prevention analysis for an <see cref="AdvancedPayment"/>.
    /// </summary>
    public class AdvancedPaymentAdditionalInfoPayer
    {
        /// <summary>
        /// Payer's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Payer's last name (family name).
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Payer's phone number details.
        /// </summary>
        public Phone Phone { get; set; }

        /// <summary>
        /// Payer's residential or billing address.
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Date when the payer registered on the merchant's site. Helps assess account age for fraud analysis.
        /// </summary>
        public DateTime? RegistrationDate { get; set; }
    }
}
