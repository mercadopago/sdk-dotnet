namespace MercadoPago.Resource.Payment
{
    using System;

    /// <summary>
    /// Information about the card used to process a payment, including
    /// masked card number, expiration, and cardholder data.
    /// Only present for card-based payment methods (credit, debit, prepaid).
    /// </summary>
    public class PaymentCard
    {
        /// <summary>
        /// Unique identifier of the card, if stored in the MercadoPago vault.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Last four digits of the card number (e.g., "4905").
        /// Used for display and identification purposes.
        /// </summary>
        public string LastFourDigits { get; set; }

        /// <summary>
        /// First six digits (BIN) of the card number (e.g., "423564").
        /// Used to identify the issuer and card type.
        /// </summary>
        public string FirstSixDigits { get; set; }

        /// <summary>
        /// Four-digit expiration year of the card (e.g., 2025).
        /// </summary>
        public int? ExpirationYear { get; set; }

        /// <summary>
        /// Expiration month of the card (1-12).
        /// </summary>
        public int? ExpirationMonth { get; set; }

        /// <summary>
        /// Date and time when this card record was first created in MercadoPago.
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Date and time of the last update to this card's stored information.
        /// </summary>
        public DateTime? DateLastUpdated { get; set; }

        /// <summary>
        /// Cardholder information, including the name printed on the card
        /// and the cardholder's identification document.
        /// </summary>
        /// <seealso cref="PaymentCardholder"/>
        public PaymentCardholder Cardholder { get; set; }
    }
}
