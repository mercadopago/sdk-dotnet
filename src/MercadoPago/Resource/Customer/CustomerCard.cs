namespace MercadoPago.Resource.Customer
{
    using System;
    using MercadoPago.Http;

    /// <summary>
    /// Represents a payment card saved for a <see cref="Customer"/> in
    /// MercadoPago. Cards are tokenized; only masked digits (BIN and last four)
    /// are stored. Use <see cref="Client.Customer.CustomerCardClient"/> to add,
    /// retrieve, and delete customer cards.
    /// </summary>
    public class CustomerCard : IResource
    {
        /// <summary>
        /// Unique identifier of the saved card.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Identifier of the <see cref="Customer"/> who owns this card.
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Expiration month of the card (1-12).
        /// </summary>
        public int? ExpirationMonth { get; set; }

        /// <summary>
        /// Four-digit expiration year of the card.
        /// </summary>
        public int? ExpirationYear { get; set; }

        /// <summary>
        /// First six digits of the card number (BIN). Used to identify the
        /// issuer and card type.
        /// </summary>
        public string FirstSixDigits { get; set; }

        /// <summary>
        /// Last four digits of the card number, useful for display to the
        /// customer.
        /// </summary>
        public string LastFourDigits { get; set; }

        /// <summary>
        /// Payment method associated with this card (e.g. Visa, Mastercard).
        /// </summary>
        public CustomerCardPaymentMethod PaymentMethod { get; set; }

        /// <summary>
        /// Security code (CVV/CVC) configuration for this card.
        /// </summary>
        public CustomerCardSecurityCode SecurityCode { get; set; }

        /// <summary>
        /// Card issuer (bank or financial institution) information.
        /// </summary>
        public CustomerCardIssuer Issuer { get; set; }

        /// <summary>
        /// Cardholder name and identification details.
        /// </summary>
        public CustomerCardCardholder Cardholder { get; set; }

        /// <summary>
        /// Date and time when this card was saved.
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Date and time of the last update to this card record.
        /// </summary>
        public DateTime? DateLastUpdated { get; set; }

        /// <summary>
        /// Raw HTTP response returned by the MercadoPago API for the request
        /// that produced this resource.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
