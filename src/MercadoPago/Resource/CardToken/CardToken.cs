namespace MercadoPago.Resource.CardToken
{
    using System;
    using MercadoPago.Http;

    /// <summary>
    /// Represents a card token returned by the MercadoPago Card Token API.
    /// A card token is a single-use, short-lived reference to card data that
    /// allows you to process payments without handling sensitive card details
    /// directly. Use <see cref="Client.CardToken.CardTokenClient"/> to create
    /// card tokens.
    /// </summary>
    public class CardToken : IResource
    {
        /// <summary>
        /// Unique card token identifier. Pass this value in a payment request
        /// instead of raw card data.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Identifier of the saved card from which this token was generated,
        /// if applicable.
        /// </summary>
        public string CardId { get; set; }

        /// <summary>
        /// Current status of the card token (e.g. <c>active</c>,
        /// <c>used</c>).
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Date and time when this card token was created.
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Date and time of the last update to this card token.
        /// </summary>
        public DateTime? DateLastUpdated { get; set; }

        /// <summary>
        /// Expiration date and time after which the token can no longer be used.
        /// </summary>
        public DateTime? DateDue { get; set; }

        /// <summary>
        /// Indicates whether the card number passed Luhn algorithm validation.
        /// </summary>
        public bool? LuhnValidation { get; set; }

        /// <summary>
        /// Indicates whether this token was created in production mode
        /// (<c>true</c>) or sandbox mode (<c>false</c>).
        /// </summary>
        public bool? LiveMode { get; set; }

        /// <summary>
        /// Indicates whether end-to-end encryption of the security code (ESC)
        /// is required for this token.
        /// </summary>
        public bool? RequireEsc { get; set; }

        /// <summary>
        /// Expected length of the card's security code (CVV/CVC).
        /// </summary>
        public int? SecurityCodeLength { get; set; }

        /// <summary>
        /// Raw HTTP response returned by the MercadoPago API for the request
        /// that produced this resource.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
