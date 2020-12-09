namespace MercadoPago.Resource.Customer
{
    using System;
    using MercadoPago.Http;

    /// <summary>
    /// Customer card data.
    /// </summary>
    public class CustomerCard : IResource
    {
        /// <summary>
        /// Card ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Customer ID.
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Card's expiration month.
        /// </summary>
        public int? ExpirationMonth { get; set; }

        /// <summary>
        /// Card's expiration year.
        /// </summary>
        public int? ExpirationYear { get; set; }

        /// <summary>
        /// Card's first six digits.
        /// </summary>
        public string FirstSixDigits { get; set; }

        /// <summary>
        /// Card's last four digits.
        /// </summary>
        public string LastFourDigits { get; set; }

        /// <summary>
        /// Payment method information.
        /// </summary>
        public CustomerCardPaymentMethod PaymentMethod { get; set; }

        /// <summary>
        /// Security code information.
        /// </summary>
        public CustomerCardSecurityCode SecurityCode { get; set; }

        /// <summary>
        /// Issuer information.
        /// </summary>
        public CustomerCardIssuer Issuer { get; set; }

        /// <summary>
        /// Carholder information.
        /// </summary>
        public CustomerCardCardholder Cardholder { get; set; }

        /// <summary>
        /// Card's date of creation.
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Card's date last update.
        /// </summary>
        public DateTime? DateLastUpdated { get; set; }

        /// <summary>
        /// Response from API.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
