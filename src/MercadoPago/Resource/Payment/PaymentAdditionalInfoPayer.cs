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
    }
}
